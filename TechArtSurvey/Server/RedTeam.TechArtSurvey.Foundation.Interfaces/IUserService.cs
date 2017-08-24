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
        Task<IServiceResponse> UpdateAsync(EditUserDto user);
        Task<IServiceResponse> DeleteByIdAsync(int id);
        Task<IServiceResponse<EditUserDto>> GetByIdAsync(int id);
        Task<IServiceResponse> GetByEmailAsync(string email);
        Task<IServiceResponse> CheckByEmailAsync(string email);
        Task<IServiceResponse<IReadOnlyCollection<EditUserDto>>> GetAllAsync();
        Task<IServiceResponse> GetPasswordResetTokenAsync(int userId);
        Task<IServiceResponse> SendConfirmationEmailAsync(int userId, string resetPasswordToken, string callbackUrl);
        Task<IServiceResponse> CheckPasswordResetTokenAsync(int userId, string resetPasswordToken);
        Task<IServiceResponse> ResetUserPasswordAsync(int userId, string resetPasswordToken, string newPassword);
    }
}