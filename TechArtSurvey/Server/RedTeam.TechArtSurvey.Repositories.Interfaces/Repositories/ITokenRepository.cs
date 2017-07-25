using System.Threading.Tasks;

using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities;

namespace RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories
{
    public interface ITokenRepository : IRepository<Token>
    {
        Task<Token> GetTokenByValueAsync(string value);
    }
}