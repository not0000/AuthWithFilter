using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthWithFilter.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            
            //僅為範例，可考慮製作已經登出 的提示訊息
            return RedirectToAction("Index");
        }
        
        public ActionResult CheckLogin(string id, string pw)
        {
            //僅為範例，實務上請到DB去找密碼驗證
            if (id == "1" && pw == "1") {

                CoreUtil.MySession.Current.LoginID = "1";
                CoreUtil.MySession.Current.LoginName = "1號使用者";

                return RedirectToAction("Index","Home");
            }
            else {
                //僅為範例，記得要製作 帳號或密碼錯誤 的提示訊息
                return RedirectToAction("Index");
            }

        }
    }
}