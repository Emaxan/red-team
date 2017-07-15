using System.Collections.Generic;
using System.Threading.Tasks;

using RedTeam.TechArtSurvey.Foundation.DTO;

namespace RedTeam.TechArtSurvey.Foundation.Interfaces
{
    public interface IUserService
    {
        Task Create(UserDto user);
        Task Update(UserDto user);
        Task DeleteAsync(int id);
        Task<UserDto> GetAsync(int id);
        Task<IReadOnlyCollection<UserDto>> GetAllAsync();
    }
}