using System;

namespace Core.Services.Limiters.Models
{
    public class UserActivityLimiterResponse
    {
        public Guid UserId { get; init; }
        public bool IsEnable { get; init; }
        public TimeSpan? RemainingTime { get; init; }

        public static UserActivityLimiterResponse OK(Guid userId) => new()
        {
            UserId = userId,
            IsEnable = true,
        };

        public static UserActivityLimiterResponse Error(Guid userId, TimeSpan remainingTime) => new()
        {
            UserId = userId,
            IsEnable = false,
            RemainingTime = remainingTime,
        };
    }
}
