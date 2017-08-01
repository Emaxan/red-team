using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RedTeam.Repositories.Identity.Security
{
    class ClaimsManager
    {
        public ClaimsIdentity GetClaims(User user)
        {
            var claims = new ClaimsIdentity(OAuthDefaults.AuthenticationType);
            claims.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            claims.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            claims.AddClaim(new Claim(ClaimTypes.Role, user.Role.RoleName.ToString()));
            return claims;
        }
    }
}
