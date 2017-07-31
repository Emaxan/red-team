using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

using Ninject;

namespace RedTeam.TechArtSurvey.WebApi.Utils
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        public static IKernel Kernel { get; private set; }


        public NinjectDependencyResolver(IKernel kernel)
        {
            Kernel = kernel;
        }

        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}