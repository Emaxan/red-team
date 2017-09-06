using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNet.Identity;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;
using RedTeam.TechArtSurvey.Repositories.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Identity.Security;

namespace RedTeam.TechArtSurvey.Foundation.Identity.Stores
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
            GC.SuppressFinalize(this);
        }

        public async Task<User> FindByIdAsync(int userId)
        {
            var user = await _uow.Users.GetByIdAsync(Convert.ToInt32(userId), u => u.Role);

            return user;
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            var user = await _uow.Users.GetUserByEmailAsync(userName, u => u.Role);

            return user;
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            var user = await _uow.Users.GetUserByEmailAsync(email, u => u.Role);

            return user;
        }

        public async Task UpdateAsync(User user)
        {
            _uow.Users.Update(user);
            await _uow.SaveAsync();
        }

        public Task SetEmailAsync(User user, string email)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.Email = email;

            return Task.CompletedTask;
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
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.Password = passwordHash;

            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var hasPassword = !string.IsNullOrEmpty(user.Password);

            return Task.FromResult(hasPassword);
        }

        public async Task AddToRoleAsync(User user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.Role = await _uow.Roles.FindByNameAsync(roleName);
            if (user.Role == null)
            {
                throw new NullReferenceException(nameof(user.Role));
            }
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

            return Task.FromResult<IList<string>>(user.Role == null
                                                      ? new List<string>()
                                                      : new List<string>
                                                        {
                                                            user.Role.RoleType.ToString()
                                                        });
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
            return await _uow.Users.GetAllAsync(u => u.Role);
        }
    }
}