using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using iTechArtSurvay.Data.Entities;
using iTechArtSurvay.Data.Interfaces;
using iTechArtSurvay.Infrastructure.DTO;
using iTechArtSurvay.Infrastructure.Infrastructure;
using iTechArtSurvay.Infrastructure.Interfaces;

namespace iTechArtSurvay.Infrastructure.Services
{
    public class UserService:IUserService
    {
        private IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Create(UserDto user)
        {
            if (user == null)
                throw new ValidationException("Не установлена сущность пользователя", "");
            User us = Database.Users.Get(user.Id);
            if(us !=null)
                throw new ValidationException("Cущность пользователя уже существует", "");
            Mapper.Initialize(cfg => cfg.CreateMap<UserDto, User>());
            Database.Users.Create(Mapper.Map<UserDto, User>(user));
        }

        public void Update(UserDto user)
        {
            if (user == null)
                throw new ValidationException("Не установлена сущность пользователя", "");
            var us = Database.Users.Get(user.Id);
            if (us == null)
                throw new ValidationException("Пользователь не найден", "");
            Database.Users.Delete(user.Id);
        }

        public void Delete(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлен id пользователя", "");
            var user = Database.Users.Get(id.Value);
            if (user == null)
                throw new ValidationException("Пользователь не найден", "");
            Database.Users.Delete(id.Value);
        }

        public UserDto Get(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлен id пользователя", "");
            var user = Database.Users.Get(id.Value);
            if (user == null)
                throw new ValidationException("Пользователь не найден", "");
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDto>());
            return Mapper.Map<User, UserDto>(user);
        }

        public IEnumerable<UserDto> GetAll()
        {
            IEnumerable<User> users = Database.Users.GetAll();
            Mapper.Initialize(cfg=>cfg.CreateMap<User,UserDto>());
            IEnumerable<UserDto> uss = Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);//TODO Here is an issue with DB " Cannot drop database "iTechArtSurvayDb" because it is currently in use." Mb Access token = null
            return uss;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}