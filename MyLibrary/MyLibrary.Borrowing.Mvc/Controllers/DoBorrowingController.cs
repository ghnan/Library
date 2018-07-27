using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyLibrary.Borrowing.Mvc.Controllers
{
    public class DoBorrowingController : Controller
    {
        /// <summary>
        /// 借书页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Borrowing()
        {
            return View();
        }

        /// <summary>
        /// 通过书名借阅书籍
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DoBorrowingByName()
        {
            string BookName = Request.Form["BookName"];
            string StudentName = Request.Form["StudentName"];
            bool flag = Services.BorrowingService.DoBorrowingByName(BookName, StudentName);
            if (flag)
            {
                return RedirectToAction("StudentMain", "Account", new { area = "Student" });
            }
            else return Content("书名输入错误");
        }

        /// <summary>
        /// 还书页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Return()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoReturnByName()
        {
            string BookName = Request.Form["BookName"];
            string StudentName = Request.Form["StudentName"];
            bool flag = Services.BorrowingService.DoReturnByName(BookName,StudentName);
            if (flag)
            {
                return RedirectToAction("StudentMain", "Account", new { area = "Student" });
            }
            else
            {
                return Content("输入信息有误");
            }
        }

        public ActionResult ShowBorrowingInfo()
        {
            List<MyLibrary.Model.Entities.Borrowing> borrowings = new List<Model.Entities.Borrowing>();
            borrowings = MyLibrary.Borrowing.Services.BorrowingService.GetBorrowings();
            return View(borrowings);
        }

    }
}
