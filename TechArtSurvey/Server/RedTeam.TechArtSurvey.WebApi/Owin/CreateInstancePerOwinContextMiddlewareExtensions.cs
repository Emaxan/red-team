using System;
using Microsoft.Owin;
using Owin;

namespace RedTeam.TechArtSurvey.WebApi.Owin
{
    public static class CreateInstancePerOwinContextMiddlewareExtensions
    {
        public static IAppBuilder CreateInstancePerOwinContext<T>(this IAppBuilder builder, Func<IOwinContext, T> factory) where T : class
        {
            builder.Use(typeof(CreateInstancePerRequestMiddleware<T>), factory);

            return builder;
        }
    }
}