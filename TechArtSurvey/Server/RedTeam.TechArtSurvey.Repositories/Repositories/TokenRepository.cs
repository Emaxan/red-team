using System.Data.Entity;
using System.Threading.Tasks;

using RedTeam.Logger;
using RedTeam.Repositories.EntityFramework.Repositories;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories;

namespace RedTeam.TechArtSurvey.Repositories.Repositories
{
    public class TokenRepository : Repository<Token>, ITokenRepository
    {
        public TokenRepository(IDbContext context)
            : base(context)
        {
        }


        public async Task<Token> GetTokenByValueAsync(string value)
        {
            LoggerContext.Logger.Info($"Get token with value = {value}");
            return await DbSet.FirstOrDefaultAsync(token => token.Value == value);
        }
    }
}