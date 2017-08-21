using System;
using Autofac;
using Autofac.Integration.Owin;
using Microsoft.Owin;
using RedTeam.TechArtSurvey.WebApi.Provider;

namespace RedTeam.TechArtSurvey.WebApi
{
    public class AutofacServiceProvider : IServiceProvider
    {
        private readonly IOwinContext _context;


        public AutofacServiceProvider(IOwinContext context)
        {
            _context = context;
        }


        public object GetService(Type serviceType)
        {
            var autofacLifeTimeScope = _context.GetAutofacLifetimeScope();
            var service = autofacLifeTimeScope.Resolve(serviceType);

            return service;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}