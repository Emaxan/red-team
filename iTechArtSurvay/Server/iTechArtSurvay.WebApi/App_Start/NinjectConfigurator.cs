using iTechArtSurvay.Infrastructure.Interfaces;
using iTechArtSurvay.Infrastructure.Services;
using Ninject;

namespace iTechArtSurvay.WebApi
{
    public class NinjectConfigurator
    {
        public void Configure(IKernel _kernel)
        {
            AddBindings(_kernel);
        }

        private void AddBindings(IKernel kernel)
        {
            kernel.Bind<IUserService>().To<UserService>();
        }
    }
}