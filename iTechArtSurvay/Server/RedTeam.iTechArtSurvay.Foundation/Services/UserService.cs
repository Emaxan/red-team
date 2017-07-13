using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private IUnitOfWork Database { get; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Create(UserDto user)
        {
            if ( user == null )
            {
                throw new ValidationException("Не установлена сущность пользователя", "");
            }
            var us = Database.Users.GetAsync(user.Id);
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
            var us = Database.Users.GetAsync(user.Id);
            if ( us == null )
            {
                throw new ValidationException("Пользователь не найден", "");
            }
            Mapper.Initialize(cfg => cfg.CreateMap<UserDto, User>());
            Database.Users.Delete(Mapper.Map<UserDto, User>(user));
        }

        public async Task DeleteAsync(int id)
        {
            var user = await Database.Users.GetAsync(id);
            if ( user == null )
            {
                throw new ValidationException("Пользователь не найден", "");
            }
            Database.Users.Delete(user);
        }

        public async Task<UserDto> GetAsync(int id)
        {
            var user = await Database.Users.GetAsync(id);
            if ( user == null )
            {
                throw new ValidationException("Пользователь не найден", "");
            }
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDto>());
            return Mapper.Map<User, UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await Database.Users.GetAllAsync();
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDto>());
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}