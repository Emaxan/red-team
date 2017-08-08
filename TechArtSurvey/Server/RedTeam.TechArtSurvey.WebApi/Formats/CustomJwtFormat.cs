using Microsoft.Owin.Security;
using System;
using System.IdentityModel.Tokens;

namespace RedTeam.TechArtSurvey.WebApi.Formats
{
    public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        public string Protect(AuthenticationTicket ticket)
        {
            var identity = ticket.Identity;
            var claims = identity.Claims;
            var handler = new JwtSecurityTokenHandler();

            var issuer = "localhost";
            var audience = "all";
            var key = Convert.FromBase64String("401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1");
            var securityKey = new InMemorySymmetricSecurityKey(key);
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest, null);
            var now = DateTime.UtcNow;
            var expires = now.AddMinutes(15);
            var token = new JwtSecurityToken(issuer: issuer, audience: audience, claims: claims, notBefore: now, expires: expires, signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}