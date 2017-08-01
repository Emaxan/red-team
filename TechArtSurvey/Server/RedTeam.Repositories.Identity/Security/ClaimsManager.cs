using Microsoft.Owin.Security.OAuth;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using System.Security.Claims;

namespace RedTeam.Repositories.Identity.Security
{
    public static class ClaimsManager
    {
        public static ClaimsIdentity GetClaims(User user)
        {
            var claims = new ClaimsIdentity(OAuthDefaults.AuthenticationType);
            claims.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            claims.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            claims.AddClaim(new Claim(ClaimTypes.Role, user.Role.RoleName.ToString()));
            return claims;
        }
    }
}
