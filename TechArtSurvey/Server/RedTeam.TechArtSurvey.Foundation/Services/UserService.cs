using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Foundation.DTO;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Repositories.Interfaces;

namespace RedTeam.TechArtSurvey.Foundation.Services
{
    [UsedImplicitly]
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<int> Create(UserDto user)
        {
            var us = await _uow.Users.GetUserByEmailAsync(user.Email);
            if ( us != null )
            {
                throw new ArgumentException("User already exist", nameof( user.Email));
            }
            var createdUser = _uow.Users.Create(_mapper.Map<UserDto, User>(user));
            await _uow.SaveAsync();
            return createdUser.Id;
        }

        public async Task Update(UserDto user)
        {
            var us = await _uow.Users.GetUserByEmailAsync(user.Email);
            if ( us == null )
            {
                throw new ArgumentException("User not found", nameof( user.Email));
            }
            
            _uow.Users.Update(_mapper.Map<UserDto, User>(user));
            await _uow.SaveAsync();
        }

        public async Task DeleteAsync(UserDto user)
        {
            var us = await _uow.Users.GetUserByEmailAsync(user.Email);
            if ( us == null )
            {
                throw new ArgumentException("User not found", nameof(user.Email));
            }
            _uow.Users.Delete(us);
            await _uow.SaveAsync();
        }

        public async Task<UserDto> GetAsync(int id)
        {
            var user = await _uow.Users.GetAsync(id);
            if (user == null)
            {
                throw new ArgumentException("User not found", nameof(id));
            }
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user = await _uow.Users.GetUserByEmailAsync(email);
            if (user == null)
            {
                throw new ArgumentException("User not found", nameof(email));
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