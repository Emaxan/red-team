using System;
using System.Reflection;
using System.Web.Compilation;

using RedTeam.Logger.Interfaces;

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