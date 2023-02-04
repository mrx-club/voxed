using System;

namespace Voxed.WebApp.Extensions
{
    public static class DateTimeOffsetExtension
    {
        private const int IsNewIntervalInHours = -24;

        public static bool IsNew(this DateTimeOffset dateTime)
        {
            return dateTime.Date > DateTime.Now.Date.AddHours(IsNewIntervalInHours);
        }
    }
}
