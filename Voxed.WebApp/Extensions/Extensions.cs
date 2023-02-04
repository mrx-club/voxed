using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;

namespace Voxed.WebApp.Extensions
{
    public static class Extensions
    {
        public static string ToTimeAgo(this DateTime dt)
        {
            TimeSpan span = DateTime.Now - dt;
            if (span.Days > 365)
            {
                int years = (span.Days / 365);
                if (span.Days % 365 != 0)
                    years += 1;
                return $"{years}y";
            }
            if (span.Days > 30)
            {
                int months = (span.Days / 30);
                if (span.Days % 31 != 0)
                    months += 1;
                return $"{months}M";
            }
            if (span.Days > 0)
                return $"{span.Days}d";
            if (span.Hours > 0)
                return $"{span.Hours}h";
            if (span.Minutes > 0)
                return $"{span.Minutes}m";
            if (span.Seconds > 1)
                return $"{span.Seconds}s";
            if (span.Seconds <= 0)
                return "Ahora";
            return "Ahora";
        }

        public static string GetErrorMessage(this ModelStateDictionary model)
        {
            return model.Root.Children
                    .Where(x => x.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                    .First().Errors.FirstOrDefault().ErrorMessage;
        }
    }
}
