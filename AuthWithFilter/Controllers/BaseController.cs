using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AuthWithFilter.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnAuthorization(AuthorizationContext requestContext)
        {
            // [C#] How to redirect from OnActionExecuting in Base Controller?
            // https://code.i-harness.com/en/q/310db6

            base.OnAuthorization(requestContext);
            // 傳統session的寫法長這樣，缺點是不容易盤點Session物件到底有多少東西，用MySession的方式把整個物件放進去，以後要管理就方便了
            // if (Session["LoginID"] != "OK") 

            if (CoreUtil.MySession.Current.LoginID == null)
            {
                requestContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                    {{"controller", "Login"}, {"action", "Index"}});
            }

        }
    }
}