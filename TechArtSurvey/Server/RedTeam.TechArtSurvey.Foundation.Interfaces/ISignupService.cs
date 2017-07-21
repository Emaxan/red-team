using System.Threading.Tasks;

using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.Foundation.Interfaces
{
    public interface ISignupService
    {
        Task<IServiceResponse> CreateAsync(UserDto user);
    }
}