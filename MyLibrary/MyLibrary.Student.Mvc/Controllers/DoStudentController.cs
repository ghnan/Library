using System.Collections.Generic;
using System.Web.Mvc;
namespace MyLibrary.Student.Mvc.Controllers
{
    /// <summary>
    /// 学生账户管理控制器
    /// </summary>
    public class DoStudentController : Controller
    {
        /// <summary>
        /// 登录显示界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

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
            string flag = Request.Form["optionsRadiosinline"];
            int judge = Services.StudentService.DoLogin(flag,student);
            switch (judge)
            {
                case 0:return RedirectToAction("AdminMain", "DoAdmin",new { Area = "Admin" });

                case 1:return Content("用户名为空");
 
                case 2:return RedirectToAction("StudentMain");
                    
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
        public ActionResult StudentMain()
        {
            List<Model.Entities.Book> booklist = Book.Services.BookService.GetBooks();
            return View(booklist);
        }
    }
}
