using RedTeam.Logger.Interfaces;
using System;
using System.Reflection;
using System.Web.Compilation;

namespace RedTeam.Logger
{
    public static class LoggerFactory
    {
        private static readonly Assembly WebApi = BuildManager.GetGlobalAsaxType().BaseType.Assembly;

        public static ILog GetLogger(Type type)
        {
            var log = log4net.LogManager.GetLogger(WebApi, type);
            return new Log(log);
        }
    }
}