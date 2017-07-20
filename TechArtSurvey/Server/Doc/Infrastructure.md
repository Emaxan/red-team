# Server infrastructure #

---

### Data Access Layer ###
* *RedTeam.iTechArtSurvay.DomainModel*: (description)
* *RedTeam.iTechArtSurvay.Repositories*: (description)
* *RedTeam.Repositories*: (description)
* *RedTeam.Repositories.EntityFramework*: (description)

### Business Logic Layer ###
* *RedTeam.iTechArtSurvay.Foundation*: (description)

    
### Presentation Layer ###
* *RedTeam.iTechArtSurvay.WebApi*: (description)

---

### RedTeam.iTechArtSurvay.DomainModel ###
Project include:

  * Interfaces:
    1. IEntity


  * Domain models:
    1. User;

### RedTeam.iTechArtSurvay.Repositories ###
Project include:

  * Contexts for database:
    1. ITechArtSurvayContext;


  * Migration's files and configurations for it (you can find more information about migrations [here](./DatabaseMigrations.md).


### RedTeam.Repositories ###
Project include interfaces of general classes:

  1. IDatabaseInitialiser;
  2. IDbConext;
  3. IRepositiry;
  4. IUnitOfWork;
  5. IUserRepository;

### RedTeam.Repositories.EntityFramework ###
Project include implementations of general classes for EntityFramework:

  1. Repositiry;
  2. UnitOfWork;
  3. UserRepository;

All models should implement IEntity interface.

### RedTeam.iTechArtSurvay.Foundation ###
Project include:
  * Interfaces and implementations of services:
    1. UserService;


  * Data Transfer Objects:
    1. UserDTO;


  * Complex business logic of application.

### RedTeam.iTechArtSurvay.WebApi ###
Project include:
  * Ninject container;


  * Controllers:
    1. UserController;


  * Filters:
    1. ArrayExceptionAttribute;
    2. CustomActionAttribute;
    3. CustomAuthenticationAttribute;
    4. CustomAuthorizationAttribute;


  * Utils:
    1. NinjectDependencyResolver;
    2. UserFormatter;
