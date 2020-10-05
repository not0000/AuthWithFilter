using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthWithFilter.CoreUtil
{
    public class MySession
    {
        // 參考來源
        // https://stackoverflow.com/questions/621549/how-to-access-session-variables-from-any-class-in-asp-net

        private MySession()
        {
            //可以在此給予初始值
            Property1 = "default value";
        }

        // Gets the current session.
        public static MySession Current
        {
            get
            {
                MySession session = (MySession)HttpContext.Current.Session["__MySession__"];
                if (session == null)
                {
                    session = new MySession();
                    HttpContext.Current.Session["__MySession__"] = session;
                }
                return session;
            }
        }

        // MySession 要使用的強型別變數放在這裡，範例如下
        public string Property1 { get; set; }
        public DateTime MyDate { get; set; }
        public int RandomNumber { get; set; }
        /// <summary>
        /// 使用者帳號
        /// </summary>
        public string LoginID { get; set; }
        /// <summary>
        /// 原本的使用者帳號(最高權限切換紀錄用)
        /// </summary>
        public string OriginalLoginID { get; set; }
        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 使用者單位編號
        /// </summary>
        public string UnitID { get; set; }
        /// <summary>
        /// 使用者單位名稱
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 使用者群組
        /// </summary>
        public string RoleGroup { get; set; }


    }
}