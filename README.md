## Ejecución de Scripts de la Base de Datos

Los scripts de la base de datos están disponibles en el archivo `scriptDB.sql`, ubicado en la `raiz` del proyecto. Puedes utilizar este archivo para ejecutar los scripts necesarios en la base de datos.

Además, si lo prefieres, también tienes la opción de utilizar el archivo `docker-compose.yml` en la raíz del proyecto para levantar la base de datos en un contenedor Docker, con la configuración específica para el motor de base de datos PostgreSQL utilizado en el proyecto.

### Ejecución del Contenedor Docker

Para iniciar el contenedor, utiliza los siguientes comandos:

```bash
docker compose up -d postgres
docker compose up -d pgadmin

```