using RedTeam.TechArtSurvey.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RedTeam.TechArtSurvey.Repositories.Interfaces;
using Microsoft.AspNet.Identity;

namespace RedTeam.Identity.Stores
{
    public class ApplicationUserStore : IApplicationUserStore
    {
        private readonly ITechArtSurveyUnitOfWork _uow;


        public ApplicationUserStore(ITechArtSurveyUnitOfWork uow)
        {
            _uow = uow;
        }


        public async Task CreateAsync(User user)
        {
            user.Role = await _uow.Roles.FindRoleByTypeAsync(default(RoleTypes));
            _uow.Users.Create(user);
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
            var user = await _uow.Users.GetByIdAsync(Convert.ToInt32(userId));

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

        Task IUserEmailStore<User, int>.SetEmailConfirmedAsync(User user, bool confirmed)
        {
            return null;
        }

        public async Task<IReadOnlyCollection<User>> GetAllAsync()
        {
            return await _uow.Users.GetAllAsync();
        }
    }
}