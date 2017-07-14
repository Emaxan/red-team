using Ninject;
using RedTeam.iTechArtSurvay.Foundation.Services;
using RedTeam.TechArtSurvey.Foundation.Interfaces;

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
            kernel.Bind(typeof(IUserService<>)).To(typeof(UserService));
        }
    }
}