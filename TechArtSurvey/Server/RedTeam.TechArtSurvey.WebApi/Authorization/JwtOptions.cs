using System;
using Microsoft.Owin.Security.Jwt;

namespace RedTeam.TechArtSurvey.WebApi.Authorization
{
    public class JwtOptions : JwtBearerAuthenticationOptions
    {
        public JwtOptions()
        {
            var issuer = "localhost";
            var audience = "all";
            var key = System.Configuration.ConfigurationManager.AppSettings["SecretKey"];

            AllowedAudiences = new[] { audience };
            IssuerSecurityTokenProviders = new[]
            {
                new SymmetricKeyIssuerSecurityTokenProvider(issuer, Convert.FromBase64String(key))
            };
        }
    }
}