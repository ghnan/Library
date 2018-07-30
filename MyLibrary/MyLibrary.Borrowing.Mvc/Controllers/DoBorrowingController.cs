using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.SessionState;

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
            string Name = Request.Form["StudentName"];
            string BookName = Request.Form["BookName"];
            //string StudentName = Request.Form["StudentName"];
            bool flag = Services.BorrowingService.DoBorrowingByName(BookName, Name);
            if (flag)
            {
                return RedirectToAction("StudentMain", "DoStudent", new { area = "Student" });
            }
            else return Content("借阅失败，可能是书籍未归还或者书籍名称输入错误");
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
            string BookName = Request.Form["BookName"];
            string StudentName = Request.Form["StudentName"];
            bool flag = Services.BorrowingService.DoReturnByName(BookName,StudentName);
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
