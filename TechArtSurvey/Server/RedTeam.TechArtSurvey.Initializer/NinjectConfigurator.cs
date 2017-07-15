using Ninject;

using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Services;

namespace RedTeam.TechArtSurvey.Initializer
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