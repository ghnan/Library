using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.SessionState;

namespace MyLibrary.Borrowing.Mvc.Controllers
{
    public class DoBorrowingController : Controller
    {
        /// <summary>
        /// 通过书名借书页面
        /// </summary>
        /// <returns></returns>
        public ActionResult BorrowingByName()
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
            string name = Request.Cookies["Name"].Value;
            string bookname = Request.Form["BookName"];
            bool flag = Services.BorrowingService.DoBorrowingByName(bookname, name);
            if (flag)
            {
                return RedirectToAction("StudentMain", "DoStudent", new { area = "Student" });
            }
            else return Content("借阅失败，可能是书籍未归还或者书籍信息输入错误或者是存储量不够");
        }

        /// <summary>
        /// 通过书籍ID借书页面
        /// </summary>
        /// <returns></returns>
        public ActionResult BorrowingByID()
        {
            return View();
        }

        /// <summary>
        /// 通过书籍ID借阅书籍
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DoBorrowingByID()
        {
            int id = int.Parse(Request.Form["BookID"]);
            string name = Request.Cookies["Name"].Value;
            bool flag = Services.BorrowingService.DoBorrowingByID(id, name);
            if (flag)
            {
                return RedirectToAction("StudentMain", "DoStudent", new { area = "Student" });
            }
            else return Content("借阅失败，可能是书籍未归还或者书籍信息输入错误或者是存储量不够");
        }

        /// <summary>
        /// 还书页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Return()
        {
            return View();
        }

        /// <summary>
        /// 通过书名归还书籍
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DoReturnByName()
        {
            string bookName = Request.Form["BookName"];
            string studentName = Request.Cookies["Name"].Value;
            bool flag = Services.BorrowingService.DoReturnByName(bookName,studentName);
            if (flag)
            {
                return RedirectToAction("StudentMain", "DoStudent", new { area = "Student" });
            }
            else
            {
                return Content("归还失败，可能是书籍未借阅或者书籍名称输入错误");
            }
        }

        /// <summary>
        /// 显示借阅信息
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowBorrowingInfo()
        {
            List<MyLibrary.Model.Entities.Borrowing> borrowings = new List<Model.Entities.Borrowing>();
            borrowings = MyLibrary.Borrowing.Services.BorrowingService.GetBorrowings();
            return View(borrowings);
        }

    }
}
