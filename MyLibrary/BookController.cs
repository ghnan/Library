using System.Web.Mvc;
using MyLibrary.Book.Services;

namespace MyLibrary.Book.Mvc.Controllers
{
    /// <summary>
    /// 书籍管理控制器
    /// </summary>
    public class BookController : Controller
    {
      
        public ActionResult AddBook(Model.Entities.Book book)
        {
            Service.AddBook();
            return View();

        }
    }
}
