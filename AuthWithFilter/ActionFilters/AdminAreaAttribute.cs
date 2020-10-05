using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AuthWithFilter.ActionFilters
{
    public class AdminAreaAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var PermissionUserGroup = new List<string>() { "SuperAdmin", "NormalAdmin" };

            //取 RouteValue (可以拿到目前讀取的 Controller 和 Action 名稱)
            var RouteValue = filterContext.HttpContext.Request.RequestContext.RouteData.Values;

            // 在 Filter 取得 Querystring 的方法
            if (RouteValue["Action"].ToString()=="AdminArea" && !PermissionUserGroup.Contains(filterContext.HttpContext.Request.QueryString["PermissionUserGroup"]))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }


        }
    }
}