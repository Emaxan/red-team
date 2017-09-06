using RedTeam.Logger.Interfaces;
using System.Reflection;

namespace RedTeam.Logger
{
    public static class LoggerFactory
    {
        public static ILog GetLogger()
        {
            var log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            return new Log(log);
        }
    }
}