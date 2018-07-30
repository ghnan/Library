﻿using System.Collections.Generic;
using System.Web.Mvc;

namespace MyLibrary.Book.Mvc.Controllers
{
    /// <summary>
    /// 书籍管理控制器
    /// </summary>
    public class DoBookController : Controller
    {
        /// <summary>
        /// 显示添加书籍页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddBook()
        {
            return View();
        }

        /// <summary>
        ///执行添加书籍操作 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DoAddBook(Model.Entities.Book book)
        {
            if (!ModelState.IsValid)
            {
                return Content("数据校验不通过");
            }
            else
            {
                Services.BookService.AddBook(book);
                return RedirectToAction("AdminMain", "DoAdmin", new { area = "Admin" });
            }

        }

        /// <summary>
        /// 显示查询页面
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectBook()
        {
            return View();
        }

        /// <summary>
        /// 通过书籍名称查询书籍
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectBookByName(string Name)
        {
            List<Model.Entities.Book> booklist = Services.BookService.SelectBooksByName(Name);
            return View(booklist);
        }

        /// <summary>
        /// 显示学生主页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ReturnStudentMain()
        {
            return RedirectToAction("StudentMain", "DoStudent", new { Area = "Student" });
        }

        /// <summary>
        /// 删除书籍页面
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteBook()
        {
            return View();
        }

        /// <summary>
        /// 进行删除书籍操作
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteBookByName()
        {
            string BookName = Request.Form["BookName"];
            Services.BookService.DeleteBookByName(BookName);
            return RedirectToAction("Admin", "DoAdmin", new { Area = "Admin" });
        }

        /// <summary>
        /// 查看书籍信息
        /// </summary>
        /// <returns></returns>
        public ActionResult BookInfo()
        {
            List<MyLibrary.Model.Entities.Book> BookList = MyLibrary.Book.Services.BookService.GetBooks();
            return View(BookList);
        }
    }
}
