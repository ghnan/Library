using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using PagedList;

namespace MyLibrary.Student.Mvc.Controllers
{
    /// <summary>
    /// 学生账户管理控制器
    /// </summary>
    public class DoStudentController : Controller
    {
        /// <summary>
        /// 返回登录页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ReturnLogin() 
        {
            return RedirectToAction("Login","Home",new {Area = "" });
        }

        /// <summary>
        /// 登录操作页面，即判断登录类型，检测用户名、密码是否合格
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DoLogin(Model.Entities.Student student)
        {
            string name = student.StudentUserName;

            Response.Cookies["Name"].Value = student.StudentUserName;
            Response.Cookies["Name"].Expires = DateTime.Now.AddDays(1);

            string pwd = student.StudentPwd;
            string flag = Request.Form["optionsRadiosinline"];
            int judge = Services.StudentService.DoLogin(flag,student);
            switch (judge)
            {
                case 0:return RedirectToAction("DoLogin", "DoAdmin",new {Area = "Admin",name,pwd});

                case 1:return Content("用户名为空");
    
                case 2:return Redirect("StudentMain");
                    
                case 3:return Content("密码错误");
                   
                case 4:return Content("用户不存在");
                
                default:return Content("系统错误");
            }
        }
        /// <summary>
        /// 注册页面显示
        /// </summary>
        /// <returns></returns>
        public ActionResult Register() {
            return View();
        }
        /// <summary>
        /// 注册操作页面，完成把用户信息存入数据库
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DoRegister(Model.Entities.Student student)
        {
            if (ModelState.IsValid)
            {
                Services.StudentService.DoRegister(student);
                return RedirectToAction("Login","Home",new { Area=""});
            }
            return Content("输入不合法");
        }
        /// <summary>
        /// 学生页面显示
        /// </summary>
        /// <returns></returns>
        public ActionResult StudentMain(int? page)
        {
            var booklist = Book.Services.BookService.GetBooks();
            int pageNumber = page ?? 1;
            int pageSize = 3;
            booklist = booklist.OrderBy(s => s.BookID).ToList();
            IPagedList<Model.Entities.Book> books = booklist.ToPagedList(pageNumber, pageSize);
            return View(books);
        }

        /// <summary>
        /// 跳转到查询数据功能
        /// </summary>
        /// <returns></returns>
        public ActionResult RedictToBook()
        {
            string name = Request.Form["name"];
            return RedirectToAction("SelectBookByName", "DoBook", new {Area = "Book",name});
        }
    }
}
