using Microsoft.Owin;

namespace RedTeam.TechArtSurvey.WebApi.Owin
{
    public static class OwinContextExtensions
    {
        public static T Get<T>(this IOwinContext context) where T : class
        {
            var objectOfT = context.Get<T>(typeof(T).AssemblyQualifiedName);

            return objectOfT;
        }

        public static void Set<T>(this IOwinContext context, T objectOfT) where T : class
        {
            context.Set(typeof(T).AssemblyQualifiedName, objectOfT);
        }
    }
}