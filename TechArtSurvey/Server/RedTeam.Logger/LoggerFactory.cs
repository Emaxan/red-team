using System;
using System.Reflection;

using RedTeam.Logger.Interfaces;

namespace RedTeam.Logger
{
    public static class LoggerFactory
    {
        public static ILog GetLogger(Type type)
        {
            var log =
                log4net.LogManager.
                    GetLogger(Assembly.Load("RedTeam.TechArtSurvey.WebApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"),
                              type);
            return new Log(log);
        }
    }
}