using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Foundation.DTO;
using RedTeam.TechArtSurvey.Foundation.Exceptions;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Repositories.Interfaces;

namespace RedTeam.TechArtSurvey.Foundation.Services
{
    [UsedImplicitly]
    public class UserService : IUserService<UserDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task Create(UserDto user)
        {
            var us = await _uow.Users.GetAsync(user.Id);
            if ( us != null )   
            {
                throw new ValidationException("User already exist", "");
            }
            _uow.Users.Create(_mapper.Map<UserDto, User>(user));
            await _uow.SaveAsync();
        }

        public async Task Update(UserDto user)
        {
            var us = await _uow.Users.GetAsync(user.Id);
            if ( us == null )
            {
                throw new ArgumentException("User not found", "");
            }
            
            _uow.Users.Update(_mapper.Map<UserDto, User>(user));
            await _uow.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _uow.Users.GetAsync(id);
            if ( user == null )
            {
                throw new ArgumentException("User not found", "");
            }
            _uow.Users.Delete(user);
            await _uow.SaveAsync();
        }

        public async Task<UserDto> GetAsync(int id)
        {
            var user = await _uow.Users.GetAsync(id);
            if ( user == null )
            {
                throw new ArgumentException("User not found", "");
            }
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<IReadOnlyCollection<UserDto>> GetAllAsync()
        {
            var users = await _uow.Users.GetAllAsync();
            return _mapper.Map<IReadOnlyCollection<User>, IReadOnlyCollection<UserDto>>(users);
        }
    }
}