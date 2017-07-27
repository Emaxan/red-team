using AutoMapper;
using Microsoft.AspNet.Identity;
using RedTeam.Logger;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;
using RedTeam.TechArtSurvey.Repositories.Interfaces;
using System;

using System.Threading.Tasks;

namespace RedTeam.TechArtSurvey.Foundation
{
    public class UserStore : IUserStore<IUser, int>
    {
        protected readonly IDbContext Context;


        private readonly ITechArtSurveyUnitOfWork _uow;
        private readonly IMapper _mapper;


        public UserStore(ITechArtSurveyUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public Task CreateAsync(IdentityUser user)
        {
            ServiceResponse serviceResponse = new ServiceResponse();
            var us =  _uow.IdentityUsers.GetUserByEmailAsync(user.Email);
            if (us != null)
            {
                serviceResponse.Code = ServiceResponseCodes.UserAlreadyExists;
            }
            else
            {
                user.Password = _passwordHasher.HashPassword(user.Password);
                _uow.Users.Create(_mapper.Map<UserDto, User>(user));
                await _uow.SaveAsync();

                serviceResponse.Code = ServiceResponseCodes.Ok;
            }

            return serviceResponse;
        }

        public Task DeleteAsync(IdentityUser user)
        {
            _dbSet.Remove(user);
            return Task.FromResult<object>(null);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityUser> FindByIdAsync(int userId)
        {   
            return await _dbSet.FindAsync(userId);
        }

        public async Task<IdentityUser> FindByNameAsync(string userName)
        {
            return await _dbSet.FirstAsync(u => u.UserName == userName);
        }

        public Task UpdateAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }
    }
}
