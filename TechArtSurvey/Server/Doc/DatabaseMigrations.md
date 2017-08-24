## Database migrations ##

### Migration files ###

All migration files are associated with `RedTeam.TechArtSurvey.Repositories` project. So, next files you can find here.

- `Configuration.cs`

This file contains configuration of the database-migrations process. Pay attention for method called `Seed` - this method is used for adding test-data into tables every time when database is created or has migration (with the help of Database context object). Method `Seed` runs every time when you execute `update-database` command (see below) and override any changes to data that you may have made while testing the application.

- `<timestamp>_MigrationName.cs`

This file is generated after `add-migration` command (see below) and it contains the code that would create the database from scratch. It has two methods: `Up` (creates the database tables that correspond to the data model entity sets) and `Down` (deletes them).

### Work with migrations ###

Work with migrations is based on `Package Manager Console`. So, before start you should open this console.

##### Enabling migrations #####

If project doesn't have `Migrations` folder or you get this PMC-error:
> No migrations configuration type was found in the assembly 'RedTeam.TechArtSurvay.Repositories'

you should enable migrations with the help of `enable-migrations -projectname:RedTeam.TechArtSurvey.Repositories -startupprojectname:RedTeam.TechArtSurvey.WebApi` command. 

##### Creating new migration #####

If the domain-model was changed, to avoid conflicts between code and database, you should use `add-migration -projectname:RedTeam.TechArtSurvey.Repositories -startupprojectname:RedTeam.TechArtSurvey.WebApi` command, which is used for creating new migration (you can use parameter for naming migrations and I think it's good idea). In a nutshell, `add-migration` will create the template of future migration based on changes in code.

##### Updating database according to migration #####

When `add-migration` was finished successfully, you can use `update-database -projectname:RedTeam.TechArtSurvey.Repositories 
-startupprojectname:RedTeam.TechArtSurvey.WebApi` to update database according to the last generated `<timestamp>_MigrationName.cs` file. Now you don't have any conflicts between your code and database!

### Remarks ###

* If you have database, but don't have any data associated with it, just enter `update-database` command, which is described above.
* Connection string is placed at `Web.config` file of `RedTeam.TechArtSurvey.WebApi` project.

### References ###

- [Code First Migrations and Deployment with the Entity Framework in an ASP.NET MVC Application](https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application)
- [EF Migrations Command Reference](https://coding.abel.nu/2012/03/ef-migrations-command-reference/)

