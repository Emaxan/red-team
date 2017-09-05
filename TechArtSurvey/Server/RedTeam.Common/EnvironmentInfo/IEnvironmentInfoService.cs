using System;

namespace RedTeam.Common.EnvironmentInfo
{
    public interface IEnvironmentInfoService
    {
        DateTime CurrentUtcDateTime { get; }
    }
}