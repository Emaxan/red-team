using RedTeam.Logger.Interfaces;
using System;
using System.Diagnostics;

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
            _log.Info(GetClassOfCallingMethod() + message, e);
        }

        public void Error(string message, Exception e = null)
        {
            _log.Error(GetClassOfCallingMethod() + message, e);
        }

        public void Warn(string message, Exception e = null)
        {
            _log.Warn(GetClassOfCallingMethod() + message, e);
        }

        public void Fatal(string message, Exception e = null)
        {
            _log.Fatal(GetClassOfCallingMethod() + message, e);
        }

        public void Debug(string message, Exception e = null)
        {
            _log.Debug(GetClassOfCallingMethod() + message, e);
        }


        private string GetClassOfCallingMethod()
        {
            return (new StackFrame(2).GetMethod().DeclaringType?.DeclaringType?.ToString() ?? "undefined class").PadRight(80);
        }
    }
}