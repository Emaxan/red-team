using System.Threading.Tasks;

using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.Foundation.Interfaces
{
    public interface IUserService
    {
        Task<IServiceResponse> CreateAsync(UserDto user);

        Task<IServiceResponse> UpdateAsync(EditUserDto user);

        Task<IServiceResponse> DeleteByIdAsync(int id);

        Task<IServiceResponse> GetByIdAsync(int id);

        Task<IServiceResponse> GetByEmailAsync(string email);

        Task<IServiceResponse> GetClaimsByCredentialsAsync(string email, string password);
    }
}