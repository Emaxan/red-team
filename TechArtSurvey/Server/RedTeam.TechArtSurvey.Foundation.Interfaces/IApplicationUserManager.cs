using System.Threading.Tasks;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.Foundation.Interfaces
{
    public interface IApplicationUserManager
    {
        Task<IServiceResponse> CreateAsync(UserDto userDto);
        Task<IServiceResponse> DeleteByIdAsync(int id);
        Task<IServiceResponse> GetByEmailAsync(string email);
        Task<IServiceResponse> GetByIdAsync(int id);
        Task<IServiceResponse> GetClaimsByCredentialsAsync(string email, string password);
        Task<IServiceResponse> UpdateAsync(EditUserDto user);
    }
}