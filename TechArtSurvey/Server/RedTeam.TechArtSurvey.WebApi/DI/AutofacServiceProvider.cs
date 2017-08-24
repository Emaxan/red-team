using System;
using Autofac;
using Autofac.Integration.Owin;
using Microsoft.Owin;

namespace RedTeam.TechArtSurvey.WebApi.DI
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