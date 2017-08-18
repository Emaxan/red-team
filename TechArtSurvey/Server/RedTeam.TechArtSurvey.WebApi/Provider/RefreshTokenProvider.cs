using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace RedTeam.TechArtSurvey.WebApi.Provider
{
    public class RefreshTokenProvider : IAuthenticationTokenProvider
    {
        private static readonly ConcurrentDictionary<string, AuthenticationTicket> RefreshTokens = new ConcurrentDictionary<string, AuthenticationTicket>();


        public Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var guid = Guid.NewGuid().ToString();
            var refreshTokenProperties = new AuthenticationProperties(context.Ticket.Properties.Dictionary)
            {
                IssuedUtc = context.Ticket.Properties.IssuedUtc,
                ExpiresUtc = DateTime.UtcNow.AddDays(1)
            };
            var refreshTokenTicket = new AuthenticationTicket(context.Ticket.Identity, refreshTokenProperties);
            RefreshTokens.TryAdd(guid, refreshTokenTicket);
            context.SetToken(guid);

            return Task.FromResult(0);
        }

        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }

        public Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            AuthenticationTicket ticket;
            var header = context.OwinContext.Request.Headers["Authorization"];
            if (RefreshTokens.TryRemove(context.Token, out ticket))
            {
                context.SetTicket(ticket);
            }

            return Task.FromResult(0);
        }
    }
}