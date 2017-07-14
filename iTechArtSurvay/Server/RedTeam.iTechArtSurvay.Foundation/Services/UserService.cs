using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RedTeam.iTechArtSurvay.DomainModel.Entities;
using RedTeam.iTechArtSurvay.Foundation.DTO;
using RedTeam.iTechArtSurvay.Foundation.Exceptions;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Interfaces;

namespace RedTeam.iTechArtSurvay.Foundation.Services
{
    public class UserService : IUserService<UserDto>
    {
        private IUnitOfWork<User> Database { get; }

        public UserService(IUnitOfWork<User> uow)
        {
            Database = uow;
        }

        public void Create(UserDto user)
        {
            if ( user == null )
            {
                throw new ValidationException("Не установлена сущность пользователя", "");
            }
            var us = Database.Entities.GetAsync(user.Id);
            if ( us != null )
            {
                throw new ValidationException("Cущность пользователя уже существует", "");
            }
            Mapper.Initialize(cfg => cfg.CreateMap<UserDto, User>());
            Database.Entities.Create(Mapper.Map<UserDto, User>(user));
        }

        public void Update(UserDto user)
        {
            if ( user == null )
            {
                throw new ValidationException("Не установлена сущность пользователя", "");
            }
            var us = Database.Entities.GetAsync(user.Id);
            if ( us == null )
            {
                throw new ValidationException("Пользователь не найден", "");
            }
            Mapper.Initialize(cfg => cfg.CreateMap<UserDto, User>());
            Database.Entities.Delete(Mapper.Map<UserDto, User>(user));
        }

        public async Task DeleteAsync(int id)
        {
            var user = await Database.Entities.GetAsync(id);
            if ( user == null )
            {
                throw new ValidationException("Пользователь не найден", "");
            }
            Database.Entities.Delete(user);
        }

        public async Task<UserDto> GetAsync(int id)
        {
            var user = await Database.Entities.GetAsync(id) as User;
            if ( user == null )
            {
                throw new ValidationException("Пользователь не найден", "");
            }
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDto>());
            return Mapper.Map<User, UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await Database.Entities.GetAllAsync() as IEnumerable<User>;
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDto>());
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public void Dispose() { }
    }
}