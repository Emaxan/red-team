using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Repositories.Interfaces;

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
            user.Role = await _uow.Roles.FindRoleByTypeAsync(user.Role.RoleType);
            _uow.Users.Create(user);
            await _uow.SaveAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _uow.Users.Delete(user);
            await _uow.SaveAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _uow != null)
            {
                _uow.Dispose();
            }
        }

        public async Task<User> FindByIdAsync(int userId)
        {
            var user = await _uow.Users.GetByIdAsync(Convert.ToInt32(userId));

            return user;
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            var user = await _uow.Users.GetUserByEmailAsync(userName);

            return user;
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            var user = await _uow.Users.GetUserByEmailAsync(email);

            return user;
        }

        public async Task UpdateAsync(User user)
        {
            _uow.Users.Update(user);
            await _uow.SaveAsync();
        }

        public async Task SetEmailAsync(User user, string email)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.Email = email;
        }

        public async Task<string> GetEmailAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            return user.Email;
        }

        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            throw new NotImplementedException();
        }

        Task IUserEmailStore<User, int>.SetEmailConfirmedAsync(User user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<User>> GetAllAsync()
        {
            return await _uow.Users.GetAllAsync();
        }
    }
}