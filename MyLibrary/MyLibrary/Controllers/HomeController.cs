using System;
using System.Web;
using System.Web.Mvc;

namespace MyLibrary.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 登录显示界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }
    }
}