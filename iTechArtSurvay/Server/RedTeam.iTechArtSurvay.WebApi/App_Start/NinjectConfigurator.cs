using Ninject;
using RedTeam.iTechArtSurvay.Foundation.Interfaces;
using RedTeam.iTechArtSurvay.Foundation.Services;

namespace RedTeam.iTechArtSurvay.WebApi
{
    public class NinjectConfigurator
    {
        public void Configure(IKernel kernel)
        {
            AddBindings(kernel);
        }

        private void AddBindings(IKernel kernel)
        {
            kernel.Bind<IUserService>().To<UserService>();
        }
    }
}