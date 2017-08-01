using Microsoft.AspNet.Identity;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Claims;
using RedTeam.TechArtSurvey.Repositories.Interfaces;

namespace RedTeam.Identity.Stores
{
    public class ApplicationUserstore : IUserStore<User, int>, IUserEmailStore<User, int>
    {
        private ITechArtSurveyUnitOfWork _uow;


        public ApplicationUserstore(ITechArtSurveyUnitOfWork uow)
        {
            _uow = uow;
        }


        public async Task CreateAsync(User user)
        {
            user.Role = await _uow.Roles.FindRoleByTypeAsync(default(RoleTypes));
            var result = _uow.Users.Create(user);
            await _uow.SaveAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _uow.Users.Delete(user);
        }

        public void Dispose()
        {
            _uow.Dispose();
        }

        public async Task<User> FindByIdAsync(int userId)
        {
            var user = await _uow.Users.GetAsync(Convert.ToInt32(userId));

            return user;
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            return new User();
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            var user = await _uow.Users.GetUserByEmailAsync(email);

            return user;
        }

        public async Task UpdateAsync(User user)
        {
            _uow.Users.Update(user);
        }

        public async Task SetEmailAsync(User user, string email)
        {

        }

        public async Task<string> GetEmailAsync(User user)
        {
            return user.Email;
        }

        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task SetEmailConfirmedAsync(User user, bool confirmed)
        {

        }
    }
}