using System.Collections.Generic;
using System.Threading.Tasks;

using RedTeam.TechArtSurvey.Foundation.DTO;

namespace RedTeam.TechArtSurvey.Foundation.Interfaces
{
    public interface IUserService
    {
        Task<int> Create(UserDto user);
        Task Update(UserDto user);
        Task DeleteAsync(UserDto user);
        Task<UserDto> GetAsync(int id);
        Task<UserDto> GetUserByEmailAsync(string email);
        Task<IReadOnlyCollection<UserDto>> GetAllAsync();
    }
}