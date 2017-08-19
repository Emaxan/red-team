using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Repositories.Interfaces;
using JetBrains.Annotations;
using RedTeam.Identity.Security;

namespace RedTeam.Identity.Stores
{
    [UsedImplicitly]
    public class ApplicationUserStore : IApplicationUserStore
    {
        private readonly ITechArtSurveyUnitOfWork _uow;


        public ApplicationUserStore(ITechArtSurveyUnitOfWork uow)
        {
            _uow = uow;
        }


        public async Task CreateAsync(User user)
        {
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
            if ( disposing )
            {
                _uow?.Dispose();
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

        public Task SetEmailAsync(User user, string email)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            throw new NotImplementedException();
        }

        Task IUserEmailStore<User, int>.SetEmailConfirmedAsync(User user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task AddToRoleAsync(User user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.Role = await _uow.Roles.FindByNameAsync(roleName);
            _uow.Users.Update(user);
            await _uow.SaveAsync();
        }

        public Task RemoveFromRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (user.Role == null)
            {
                return Task.FromResult<IList<string>>(new List<string>());
            }

            return Task.FromResult<IList<string>>(new List<string> { user.Role.RoleType.ToString() });
        }

        public Task<bool> IsInRoleAsync(User user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (user.Role == null)
            {
                throw new ArgumentNullException(nameof(user.Role));
            }

            return Task.FromResult(user.Role.RoleType.ToString() == roleName);
        }

        public Task<IList<Claim>> GetClaimsAsync(User user)
        {
            IList<Claim> claims = ClaimsManager.GetClaims(user);

            return Task.FromResult(claims);
        }

        public Task AddClaimAsync(User user, Claim claim)
        {
            throw new NotImplementedException();
        }

        public Task RemoveClaimAsync(User user, Claim claim)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<User>> GetAllAsync()
        {
            return await _uow.Users.GetAllAsync();
        }
    }
}