using System.Collections.Generic;
using System.Web.Mvc;

namespace MyLibrary.Admin.Mvc.Controllers
{
    public class DoAdminController : Controller
    {
        /// <summary>
        /// 显示管理员主页
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminMain()
        {
            List<Model.Entities.Student> StudentList = MyLibrary.Student.Services.StudentService.GetSudentInfo();
            return View(StudentList);
        }

        /// <summary>
        /// 展示借阅信息
        /// </summary>
        /// <returns></returns>
        public ActionResult BorrowingInfo()
        {
            List<Model.Entities.Borrowing> BorrowingList = MyLibrary.Borrowing.Services.BorrowingService.GetBorrowings();
            return View(BorrowingList);
        }

        /// <summary>
        /// 注册管理员账户
        /// </summary>
        /// <returns></returns>
        public ActionResult Register(MyLibrary.Model.Entities.Admin admin)
        {
            Services.AdminService.Register(admin);
            return View();
        }

        /// <summary>
        /// 管理员登录控制
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public ActionResult DoLogin(string Name,string pwd)
        {
            int judge = Services.AdminService.DoLogin(Name,pwd);
            switch (judge)
            {
                case 1: return Content("用户名为空");

                case 2: return RedirectToAction("AdminMain");

                case 3: return Content("密码错误");

                case 4: return Content("用户不存在");

                default: return Content("系统错误");
            }
        }
    }
}
