using System;

using RedTeam.Logger.Interfaces;

namespace RedTeam.Logger
{
    public class Log : ILog
    {
        private readonly log4net.ILog _log;

        public Log(log4net.ILog log)
        {
            _log = log;
        }

        public bool IsInfoEnabled => _log.IsInfoEnabled;

        public bool IsErrorEnabled => _log.IsErrorEnabled;

        public bool IsWarnEnabled => _log.IsWarnEnabled;

        public bool IsFatalEnabled => _log.IsFatalEnabled;

        public bool IsDebugEnabled => _log.IsDebugEnabled;

        public void Info(string message, Exception e = null)
        {
            _log.Info(message, e);
        }

        public void Error(string message, Exception e = null)
        {
            _log.Error(message, e);
        }

        public void Warn(string message, Exception e = null)
        {
            _log.Warn(message, e);
        }

        public void Fatal(string message, Exception e = null)
        {
            _log.Fatal(message, e);
        }

        public void Debug(string message, Exception e = null)
        {
            _log.Debug(message, e);
        }
    }
}