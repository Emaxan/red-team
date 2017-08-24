using System;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace RedTeam.TechArtSurvey.WebApi.Owin
{
    public class CreateInstancePerRequestMiddleware<T> : OwinMiddleware where T : class
    {
        private readonly Func<IOwinContext, T> _factory;


        public CreateInstancePerRequestMiddleware(OwinMiddleware next, Func<IOwinContext, T> factory)
            : base(next)
        {
            _factory = factory;
        }


        public override async Task Invoke(IOwinContext context)
        {
            var objectOfT = _factory(context);
            context.Set(objectOfT);
            await Next.Invoke(context);
        }
    }
}