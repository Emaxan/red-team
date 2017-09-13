using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.Foundation.Interfaces
{
    public interface IUserService
    {
        Task<IServiceResponse<EditUserDto>> CreateAsync(EditUserDto userDto);
        Task<IServiceResponse<ClaimsIdentity>> GetClaimsByCredentialsAsync(string email, string password);
        Task<IServiceResponse> UpdateAsync(EditUserDto user);
        Task<IServiceResponse> DeleteByIdAsync(int id);
        Task<IServiceResponse<ReadUserDto>> GetByIdAsync(int id);
        Task<IServiceResponse<ReadUserDto>> GetByEmailAsync(string email);
        Task<IServiceResponse<bool>> CheckByEmailAsync(string email);
        Task<IServiceResponse<IReadOnlyCollection<ReadUserDto>>> GetAllAsync();
    }
}