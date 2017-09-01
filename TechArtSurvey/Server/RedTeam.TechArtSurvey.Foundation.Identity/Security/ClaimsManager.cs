using System.Collections.Generic;
using System.Security.Claims;
using RedTeam.TechArtSurvey.DomainModel.Entities;

namespace RedTeam.TechArtSurvey.Foundation.Identity.Security
{
    public static class ClaimsManager
    {
        public static List<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role.RoleType.ToString())
            };

            return claims;
        }
    }
}