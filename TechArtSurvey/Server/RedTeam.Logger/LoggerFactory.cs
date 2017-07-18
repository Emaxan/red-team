using System;
using System.Reflection;

using RedTeam.Logger.Interfaces;

namespace RedTeam.Logger
{
    public static class LoggerFactory
    {
        private static readonly Assembly WebApi =
            Assembly.Load("RedTeam.TechArtSurvey.WebApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
        public static ILog GetLogger(Type type)
        {
            var log = log4net.LogManager.GetLogger(WebApi, type);
            return new Log(log);
        }
    }
}