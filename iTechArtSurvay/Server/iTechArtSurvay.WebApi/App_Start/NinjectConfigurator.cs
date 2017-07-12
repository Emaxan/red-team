using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTechArtSurvay.Domain.Models;
using iTechArtSurvay.Infrastructure.Repositores;
using iTechArtSurvay.Infrastructure.Repositores.Implemenations;
using Ninject;

namespace iTechArtSurvay.WebApi.App_Start
{
    public class NinjectConfigurator
    {
        public void Configure(IKernel _kernel)
        {
            AddBindings(_kernel);
        }

        private void AddBindings(IKernel kernel)
        {
            kernel.Bind<IRepository<User>>().To<UserRepository>();
        }
    }
}