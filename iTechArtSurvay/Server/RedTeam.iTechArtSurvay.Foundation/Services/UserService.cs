using System.Collections.Generic;
using AutoMapper;
using RedTeam.iTechArtSurvay.DomainModel.Entities;
using RedTeam.iTechArtSurvay.Foundation.DTO;
using RedTeam.iTechArtSurvay.Foundation.Infrastructure;
using RedTeam.iTechArtSurvay.Foundation.Interfaces;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.iTechArtSurvay.Foundation.Services
{
    public class UserService : IUserService
    {
        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        private IUnitOfWork Database { get; }

        public void Create(UserDto user)
        {
            if ( user == null )
            {
                throw new ValidationException("Не установлена сущность пользователя", "");
            }
            var us = Database.Users.Get(user.Id);
            if ( us != null )
            {
                throw new ValidationException("Cущность пользователя уже существует", "");
            }
            Mapper.Initialize(cfg => cfg.CreateMap<UserDto, User>());
            Database.Users.Create(Mapper.Map<UserDto, User>(user));
        }

        public void Update(UserDto user)
        {
            if ( user == null )
            {
                throw new ValidationException("Не установлена сущность пользователя", "");
            }
            var us = Database.Users.Get(user.Id);
            if ( us == null )
            {
                throw new ValidationException("Пользователь не найден", "");
            }
            Database.Users.Delete(user.Id);
        }

        public void Delete(int? id)
        {
            if ( id == null )
            {
                throw new ValidationException("Не установлен id пользователя", "");
            }
            var user = Database.Users.Get(id.Value);
            if ( user == null )
            {
                throw new ValidationException("Пользователь не найден", "");
            }
            Database.Users.Delete(id.Value);
        }

        public UserDto Get(int? id)
        {
            if ( id == null )
            {
                throw new ValidationException("Не установлен id пользователя", "");
            }
            var user = Database.Users.Get(id.Value);
            if ( user == null )
            {
                throw new ValidationException("Пользователь не найден", "");
            }
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDto>());
            return Mapper.Map<User, UserDto>(user);
        }

        public IEnumerable<UserDto> GetAll()
        {
            var users = Database.Users.GetAll();
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDto>());
            var uss = Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
            return uss;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}