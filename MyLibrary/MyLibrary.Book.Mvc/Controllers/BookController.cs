using System.Web.Mvc;


namespace MyLibrary.Book.Mvc.Controllers
{
    /// <summary>
    /// 书籍管理控制器
    /// </summary>
    public class BookController : Controller
    {
        public ActionResult AddBook() {
            return View();
        }
        [HttpPost]
        public ActionResult DoAddBook(MyLibrary.Model.Entities.Book book)
        {
            int BookID = int.Parse(Request.Form["BookID"]);
            string BookName = Request.Form["BookName"];
            int BookPrice = int.Parse(Request.Form["BookPrice"]);
            string BookAuthor = Request.Form["BookAuthor"];
            int BookQuantity = int.Parse(Request.Form["BookQuantity"]);
            BookServices.BookServices.AddBook(BookID,BookName,BookPrice,BookAuthor,BookQuantity);
            return RedirectToAction("StudentMain","Account",new {area = "Student" });
        }
    }
}
