using Microsoft.Owin.Security.OAuth;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using System.Collections.Generic;
using System.Security.Claims;

namespace RedTeam.Identity.Security
{
    public static class ClaimsManager
    {
        public static List<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.Role, user.Role.RoleType.ToString()));

            return claims;
        }
    }
}