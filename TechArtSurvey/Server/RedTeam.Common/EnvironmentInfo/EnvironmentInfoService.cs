using System;
using JetBrains.Annotations;

namespace RedTeam.Common.EnvironmentInfo
{
    [UsedImplicitly]
    public class EnvironmentInfoService : IEnvironmentInfoService
    {
        public DateTime CurrentUtcDateTime => DateTime.UtcNow;
    }
}