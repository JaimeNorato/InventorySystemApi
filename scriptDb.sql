-- creacion de la base de datos my_inventory
CREATE DATABASE my_inventory;

USE my_inventory;

-- creacion de la tabla product

CREATE TABLE product (
          "ProductId" uuid NOT NULL,
          "Name" character varying(250) NOT NULL,
          "Stock" integer NOT NULL,
          CONSTRAINT "PK_product" PRIMARY KEY ("ProductId")
);

-- creacion de la tabla inventory_movement

CREATE TABLE inventory_movement (
          "InventoryMovementId" uuid NOT NULL,
          "ProductId" uuid NOT NULL,
          "Quantity" integer NOT NULL,
          "Date" timestamp with time zone NOT NULL,
          "Type" integer NOT NULL,
          "Observation" character varying(250) NOT NULL,
          CONSTRAINT "PK_inventory_movement" PRIMARY KEY ("InventoryMovementId"),
          CONSTRAINT "FK_inventory_movement_product_ProductId" FOREIGN KEY ("ProductId") REFERENCES product ("ProductId") ON DELETE CASCADE
);

CREATE INDEX "IX_inventory_movement_ProductId" ON inventory_movement ("ProductId");


-- stored procedures

-- inserta un nuevo registro en la tabla inventory_movement al crear un nuevo producto

CREATE OR REPLACE FUNCTION sp_insert_inventory_movement()
RETURNS TRIGGER
AS $$
BEGIN
    INSERT INTO inventory_movement ("InventoryMovementId", "ProductId", "Quantity", "Date", "Type", "Observation")
    VALUES (gen_random_uuid(), NEW."ProductId", NEW."Stock", now(), 0, 'Registro de nuevo producto');
    RETURN NEW;
END;
$$ LANGUAGE 'plpgsql';

-- actualiza el stock de un producto, segun el tipo de movimiento (0: entrada, 1: salida) registrado

CREATE OR REPLACE FUNCTION sp_update_stock()
RETURNS TRIGGER
AS $$
DECLARE total integer;
BEGIN
    Select COUNT(*) INTO total FROM inventory_movement WHERE "ProductId" = NEW."ProductId";
    IF total > 1 THEN
        IF NEW."Type" = 0 THEN
            UPDATE product SET "Stock" = "Stock" + NEW."Quantity" WHERE "ProductId" = NEW."ProductId";
        ELSE
            UPDATE product SET "Stock" = "Stock" - NEW."Quantity" WHERE "ProductId" = NEW."ProductId";
        END IF;
    END IF;
    RETURN NEW;
END;
$$ LANGUAGE 'plpgsql';

-- triggers

-- trigger para insertar un nuevo registro en la tabla inventory_movement al crear un nuevo producto
CREATE TRIGGER trg_insert_product
AFTER INSERT
ON product
FOR EACH ROW
EXECUTE FUNCTION sp_insert_inventory_movement();

-- trigger para actualizar el stock de un producto, segun el tipo de movimiento (0: entrada, 1: salida) registrado
CREATE TRIGGER trg_insert_inventory_movement
AFTER INSERT
ON inventory_movement
FOR EACH ROW
EXECUTE FUNCTION sp_update_stock();


