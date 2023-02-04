using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voxed.WebApp.Extensions
{
    public static class HttpContextAccessorExtensions
    {
        public static string GetIpAddress(this IHttpContextAccessor accessor)
        {
            if (!string.IsNullOrEmpty(accessor.HttpContext.Request.Headers["CF-CONNECTING-IP"]))
                return accessor.HttpContext.Request.Headers["CF-CONNECTING-IP"];

            var ipAddress = accessor.HttpContext.GetServerVariable("HTTP_X_FORWARDED_FOR");

            if (!string.IsNullOrEmpty(ipAddress))
            {
                var addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                    return addresses[0];
            }

            return accessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }
    }
}
