using Microsoft.Owin.Security;
using System;
using System.IdentityModel.Tokens;

namespace RedTeam.TechArtSurvey.WebApi.Formats
{
    public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        public string Protect(AuthenticationTicket ticket)
        {
            var claims = ticket.Identity.Claims;
            var issuer = "localhost";
            var audience = "all";
            var key = System.Configuration.ConfigurationManager.AppSettings["SecretKey"];
            var securityKey = new InMemorySymmetricSecurityKey(Convert.FromBase64String(key));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest, null);
            var now = DateTime.UtcNow;
            var expires = now.AddMinutes(15);

            var token = new JwtSecurityToken(issuer, audience, claims, now, expires, signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}