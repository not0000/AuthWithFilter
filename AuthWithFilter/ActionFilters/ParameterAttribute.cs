using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AuthWithFilter.ActionFilters
{
    public class ParameterAttribute : ActionFilterAttribute
    {
        public int ID { set; get; }
        public string FuncName  { set; get; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //模擬從資料庫取權限編號
            var PermissionList = new List<int>() { 1, 2, 3, 4, 5 };
            
            // 在 Filter 可以直接取用Controller上呼叫時帶進來的的變數
            if (!PermissionList.Contains(ID))
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }
        }
    }
}