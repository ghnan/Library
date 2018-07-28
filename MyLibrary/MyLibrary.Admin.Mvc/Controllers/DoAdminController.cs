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
    }
}
