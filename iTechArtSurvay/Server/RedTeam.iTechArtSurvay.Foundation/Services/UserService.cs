using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using RedTeam.iTechArtSurvay.DomainModel.Entities;
using RedTeam.iTechArtSurvay.Foundation.DTO;
using RedTeam.iTechArtSurvay.Foundation.Exceptions;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Interfaces;

namespace RedTeam.iTechArtSurvay.Foundation.Services
{
    [UsedImplicitly]
    public class UserService : IUserService<UserDto>
    {
        private readonly IUnitOfWork<User> _uow;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork<User> uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Create(UserDto user)
        {
            if ( user == null )
            {
                throw new ValidationException("Не установлена сущность пользователя", "");
            }
            var us = _uow.Entities.GetAsync(user.Id);
            if ( us != null )
            {
                throw new ValidationException("Cущность пользователя уже существует", "");
            }
            
            await _uow.SaveAsync();
        }

        public async Task Update(UserDto user)
        {
            if ( user == null )
            {
                throw new ValidationException("Не установлена сущность пользователя", "");
            }
            var us = _uow.Entities.GetAsync(user.Id);
            if ( us == null )
            {
                throw new ValidationException("Пользователь не найден", "");
            }
            
            _uow.Entities.Update(_mapper.Map<UserDto, User>(user));
            await _uow.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _uow.Entities.GetAsync(id);
            if ( user == null )
            {
                throw new ValidationException("Пользователь не найден", "");
            }
            _uow.Entities.Delete(user);
            await _uow.SaveAsync();
        }

        public async Task<UserDto> GetAsync(int id)
        {
            var user = await _uow.Entities.GetAsync(id);
            if ( user == null )
            {
                throw new ValidationException("Пользователь не найден", "");
            }
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _uow.Entities.GetAllAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }
    }
}