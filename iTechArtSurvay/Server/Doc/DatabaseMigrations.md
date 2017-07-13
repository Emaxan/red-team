## Database migrations ##

### Migration files ###

- `Configuration.cs`

This file contains configuration of the database-migrations process. Pay attention for method called `Seed` - this method is used for adding test-data into tables every time when database is created or has migration (with the help of Database context object). Method `Seed` runs every time when you execute `update-database` command (see below) and override any changes to data that you may have made while testing the application.

- `<timestamp>_MigrationName.cs`

This file is generated after `add-migration` command (see below) and it contains the code that would create the database from scratch. It has two methods: `Up` (creates the database tables that correspond to the data model entity sets) and `Down` (deletes them).

### Work with migrations ###

Work with migrations is based on `Package manager console`. So, before start you should open this console.

##### Enabling migrations #####

If the project doesn't have `Migrations` folder or you see this PMC-error:
> No migrations configuration type was found in the assembly 'DatabaseMigrations'

you should enable migrations with the help of `enable-migrations` command. 

/////////////

##### Creating new migration #####

If the domain-model was changed, to avoid conflicts between code and database, you should you `add-migration` command, which is used for creating new migration (you can use parameter for naming migrations and I think it's good idea). In a nutshell, `add-migration` will create the template of future migration based on changes in code.

##### Updating database according to migration #####

When `add-migration` was finished successfully, you can use `update-database` to update database according to last generated `<timestamp>_MigrationName.cs` file. Now you don't have any conflicts between your code and database!

### References ###

- [Code First Migrations and Deployment with the Entity Framework in an ASP.NET MVC Application](https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application)
- [EF Migrations Command Reference](https://coding.abel.nu/2012/03/ef-migrations-command-reference/)

