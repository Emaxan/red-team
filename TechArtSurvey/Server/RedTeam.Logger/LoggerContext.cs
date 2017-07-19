using RedTeam.Logger.Interfaces;

namespace RedTeam.Logger
{
    public static class LoggerContext
    {
        private static ILog _current;
        private static readonly ILog DefaultLogger = LoggerFactory.GetLogger(typeof(Log));


        public static ILog GetLogger {
            get {
                return _current ?? (_current = DefaultLogger);
            }
            set {
                _current = value;
            }
        }
    }
}