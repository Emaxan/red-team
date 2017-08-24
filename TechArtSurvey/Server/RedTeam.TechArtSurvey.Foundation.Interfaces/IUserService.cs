using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.Foundation.Interfaces
{
    public interface IUserService
    {
        Task<IServiceResponse<UserDto>> CreateAsync(UserDto userDto);
        Task<IServiceResponse<ClaimsIdentity>> GetClaimsByCredentialsAsync(string email, string password);
        Task<IServiceResponse<object>> UpdateAsync(EditUserDto user);
        Task<IServiceResponse<object>> DeleteByIdAsync(int id);
        Task<IServiceResponse<EditUserDto>> GetByIdAsync(int id);
        Task<IServiceResponse<object>> CheckByEmailAsync(string email);
        Task<IServiceResponse<IReadOnlyCollection<EditUserDto>>> GetAllAsync();
    }
}