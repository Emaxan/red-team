using System;
using System.Reflection;

using RedTeam.Logger.Interfaces;

namespace RedTeam.Logger
{
    public static class LogFactory
    {
        public static ILog GetLogger(Type type)
        {
            var log = log4net.LogManager.GetLogger(type);
            return new Log(log);
        }
    }
}