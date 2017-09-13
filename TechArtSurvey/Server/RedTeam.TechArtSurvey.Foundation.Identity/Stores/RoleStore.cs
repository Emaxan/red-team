using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;
using RedTeam.TechArtSurvey.Repositories.Interfaces;

namespace RedTeam.TechArtSurvey.Foundation.Identity.Stores
{
    [UsedImplicitly]
    public class RoleStore : IApplicationRoleStore
    {
        private readonly ITechArtSurveyUnitOfWork _uow;


        public RoleStore(ITechArtSurveyUnitOfWork uow)
        {
            _uow = uow;
        }


        public Task CreateAsync(Role role)
        {
            _uow.Roles.Create(role);

            return _uow.SaveAsync();
        }

        public Task DeleteAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public async Task<Role> FindByIdAsync(int roleId)
        {
            var role = await _uow.Roles.GetByIdAsync(roleId);

            return role;
        }

        public async Task<Role> FindByNameAsync(string roleName)
        {
            var role = await _uow.Roles.FindByNameAsync(roleName);

            return role;
        }

        public Task UpdateAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}