using System;

namespace RedTeam.Logger
{
    public interface ILog
    {
        bool IsInfoEnabled { get; }
        bool IsErrorEnabled { get; }
        bool IsWarnEnabled { get; }
        bool IsFatalEnabled { get; }
        bool IsDebugEnabled { get; }
        void Info(string message, Exception e = null);
        void Error(string message, Exception e = null);
        void Warn(string message, Exception e = null);
        void Fatal(string message, Exception e = null);
        void Debug(string message, Exception e = null);
    }
}