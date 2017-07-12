using iTechArtSurvay.Domain.Models;
using iTechArtSurvay.Infrastructure.Repositores;
using iTechArtSurvay.Infrastructure.Repositores.Abstract;
using iTechArtSurvay.Infrastructure.Repositores.Concrete;
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
            kernel.Bind<IUserRepository>().To<UserRepository>();
        }
    }
}