using System.Threading.Tasks;

using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;
using System.Web;
using RedTeam.TechArtSurvey.Foundation.Dto.AccountDto;

namespace RedTeam.TechArtSurvey.Foundation.Interfaces
{
    public interface IAccountService
    {
        Task<IServiceResponse> SingupAsync(UserDto user);
        Task<IServiceResponse> GetUserByCredentialsAsync(string email, string password);
        Task<IServiceResponse> LogOut(HttpContext context);
    }
}