using System.Threading.Tasks;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.Foundation.Interfaces
{
    public interface IUserService
    {
        Task<IServiceResponse> CreateAsync(UserDto userDto);
        Task<IServiceResponse> GetClaimsByCredentialsAsync(string email, string password);
        Task<IServiceResponse> UpdateAsync(EditUserDto user);
        Task<IServiceResponse> DeleteByIdAsync(int id);
        Task<IServiceResponse> GetByIdAsync(int id);
        Task<IServiceResponse> CheckByEmailAsync(string email);
        Task<IServiceResponse> GetAllAsync();
    }
}