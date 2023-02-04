using Core.Services.Limiters.Models;
using System;
using System.Collections.Generic;

namespace Core.Services.Limiters
{
    public interface IUserActivityLimiter
    {
        UserActivityLimiterResponse CanUserCreateComment(Guid userId);
        UserActivityLimiterResponse CanUserCreatePost(Guid userId);
    }
    public class UserActivityLimiter : IUserActivityLimiter
    {
        private static readonly Dictionary<Guid, DateTimeOffset> _userLastCommentAt = new();
        private static readonly Dictionary<Guid, DateTimeOffset> _userLastPostAt = new();
        private static readonly TimeSpan _activityInterval = TimeSpan.FromMinutes(2);

        public UserActivityLimiterResponse CanUserCreateComment(Guid userId) =>
            CanUserCreateActivity(userId, _userLastCommentAt);

        public UserActivityLimiterResponse CanUserCreatePost(Guid userId) =>
            CanUserCreateActivity(userId, _userLastPostAt);

        private static UserActivityLimiterResponse CanUserCreateActivity(Guid userId, Dictionary<Guid, DateTimeOffset> userLastActivity)
        {
            DateTimeOffset utcNow = DateTimeOffset.UtcNow;

            if (userLastActivity.TryGetValue(userId, out var lastActivityAt))
            {
                var timeSinceLastActivity = utcNow - lastActivityAt;
                if (timeSinceLastActivity >= _activityInterval)
                {
                    userLastActivity[userId] = utcNow;
                    return UserActivityLimiterResponse.OK(userId);
                }
                var remainingTime = timeSinceLastActivity - _activityInterval;
                return UserActivityLimiterResponse.Error(userId, remainingTime);
            }
            userLastActivity.Add(userId, utcNow);
            return UserActivityLimiterResponse.OK(userId);
        }
    }
}
