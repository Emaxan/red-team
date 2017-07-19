using System.Threading.Tasks;

using RedTeam.TechArtSurvey.Foundation.DTO;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.Foundation.Interfaces
{
    public interface IUserService
    {
        Task<IServiceResponse> CreateAsync(UserDto user);
        Task<IServiceResponse> UpdateAsync(UserDto user);
        Task<IServiceResponse> DeleteAsync(UserDto user);
        Task<IServiceResponse> GetByIdAsync(int id);
        Task<IServiceResponse> GetByEmailAsync(string email);
        Task<IServiceResponse> GetAllAsync();
    }
}