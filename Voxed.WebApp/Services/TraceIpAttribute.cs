using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using Voxed.WebApp.Models;

namespace Voxed.WebApp.Services
{
    public class TraceIPAttribute : ActionFilterAttribute
    {
        private static string[] bannedIpList = {
            "198.41.231.163",
            "198.41.231.229"
        };

        IPDetailModel model = new IPDetailModel();

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (IsUserBanned(context.HttpContext.Connection.RemoteIpAddress.ToString()))
            {
                context.Result = new JsonResult("User Banned!");
            }

            //var remoteIp = context.HttpContext.Connection.RemoteIpAddress.ToString();
            //if (context.HttpContext.Session.GetString(remoteIp) == null)
            //{
            //    model.Count = 1;
            //    model.IPAddress = remoteIp;
            //    model.Time = DateTime.Now;
            //    context.HttpContext.Session.SetString(remoteIp, JsonConvert.SerializeObject(model));
            //}
            //else
            //{
            //    var _record = JsonConvert.DeserializeObject<IPDetailModel>(context.HttpContext.Session.GetString(remoteIp));
            //    if (DateTime.Now.Subtract(_record.Time).TotalMinutes < 1 && _record.Count > 1)
            //    {
            //        context.Result = new JsonResult("Permission denined!");
            //    }
            //    else
            //    {
            //        _record.Count = _record.Count + 1;
            //        context.HttpContext.Session.Remove(remoteIp);
            //        context.HttpContext.Session.SetString(remoteIp, JsonConvert.SerializeObject(_record));
            //    }
            //}
        }

        private bool IsUserBanned(string ipAddress)
        {
            return bannedIpList.Contains(ipAddress);
        }
    }
}
