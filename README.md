# voxed.club

Proyecto free, cross-platform y open-source

> https://voxed.club

## Tech Stack :hammer_and_wrench:

- .NET 6
- PostgreSQL / MySQL / Sqlite
- Entity Framework Core
- SignalR
- AWS

## Instalacion :rocket:

- Instalar Visual Studio + .NET 6 SDK
- Clonar repositorio ejecutando comando git clone
> git clone https://github.com/.../Voxed.git
- Abrir archivo Voxed.sln con Visual Studio
- Ejectuar Voxed.WebApp desde Visual Studio

## Requisitos previos :clipboard:

### Software requerido

- [Visual Studio 2022 Community](https://visualstudio.microsoft.com/downloads/)
- [Git](https://git-scm.com/download/win)

### Software opcional

- [pgAdmin](https://www.pgadmin.org/download/)
- [Mysql Community](https://dev.mysql.com/downloads/)
- [DB Browser for SQLite](https://sqlitebrowser.org/dl/)
- [Workbench](https://dev.mysql.com/downloads/workbench/)
- [DBeaver](https://dbeaver.io/)

## Documentation :books:

La intencion de esta documentacion es brindar informacion paso a paso para una facil ejecucion. Puede necesitar ser actualizado, contener errores o pasos faltantes.
En caso de encontrar errores o cualquier inconveniente ejecutando el codigo, por favor hacerlo saber por los medios correspondientes o enviar pull request con los cambios necesarios.

## Contribucion :coffee:

Pull requests son bienvenidos.

## Bugs :bug:

- [ ] Login 
- [ ] Doble envio de noticacion al OP cuando responden etiquetandolo en un comentario del propio post
- [x] Fix buscador
- [ ] Fix Light Mode / Dark Mode
- [x] Ocultar voxs
- [x] Seguir categorias
- [x] Bug al replicar comentarios, en el cometario original no aparece el tag de la respuesta
- [x] Al hovear un tag de los comentarios se abre un una previsualizacion y no se cierra solo
- [x] Implementar >hide
- [ ] Cargas mas post en vista categoria

## Tech Debt :pencil2:

- [ ] Unit tests
- [x] Logs
- [x] Migrar a .NET 6
- [x] Migrar a postgresSQL
- [x] Multiple database providers
- [ ] Implementar clean code y clean architecture practices
- [ ] Reducir consultas a la DB
- [ ] Mejorar performance home
- [ ] Agregar roles mods
- [ ] Agregar documentacion
- [ ] Agregar automapper
- [ ] Limpiar estructura del proyecto

## Future features :bulb:

- [ ] Videos as Reels
- [ ] Implementar markdown processor. Frontmatter?
- [ ] Separar frontend / backend
- [ ] Implementar instalable PWA using web assembly / Flutter
- [ ] Implementar notificaciones push
- [ ] Implementar Tags
- [ ] Implementar Material Design 3
- [ ] Implementar moderacion basada en bots y AI cognitive services
- [ ] Post scores
- [x] External post data sources
- [ ] Board mixer based on post scores and external post sources
- [ ] Implementar CloudFront
- [ ] Redis
- [ ] Infrastruture as Code using Terraform
- [ ] CI/CD 


## Infrastructure :building_construction:

AWS Cloud services used:

- Elastic Beanstalk
- RDS
- S3 Bucket
- Route 53
- CloudWatch
- CloudFront (not implemented)
- CodePipeline (not implemented)

### Infrastructure Diagram

![Infrastructure Diagram](https://i.ibb.co/wwJzQry/Imageboard-drawio.png)

## External Services :earth_americas:

- Telegram
- Youtube

## Design Patterns

- Repository Pattern
- Dependency Injection
- Options Pattern

## Architectural Patterns

- MVC

## Design principles 

- Code First
- SOLID
- KISS
- DRY
- Composition over inheritance

## EntityFramework Migrations

Cambios base de datos a traves de EF migrations

### Add Migration

1. Especificar database provider from appsettings.json
2. Desde command console seleccionar Assembly donde guardar las migraciones
2. Ejecutar comando migracion 

> add-migration NombreDeMigracion

"# voxed" 
"# voxed" 
