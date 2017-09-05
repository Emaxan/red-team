using System;

namespace RedTeam.Common.EnvironmentInfo
{
    public class EnvironmentInfoService : IEnvironmentInfoService
    {
        public DateTime CurrentUtcDateTime => DateTime.Now;
    }
}