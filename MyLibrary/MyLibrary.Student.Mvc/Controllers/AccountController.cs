using System.Web.Mvc;
using System.Linq;
using MyLibrary.Student.DbContext;
namespace MyLibrary.Student.Mvc.Controllers
{
    /// <summary>
    /// 学生账户管理控制器
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// 定义上下文Sdb
        /// </summary>
        private StudentDbContext Sdb = new StudentDbContext();
        /// <summary>
        /// 登录显示界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
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
            string username = Request.Form["username"];
            string pwd = Request.Form["pwd"];
            if (flag == "option1")
            {
                if (username == "")
                {
                    return Content("请输入用户名");
                }
                else
                {
                    if (Sdb.Students.Any(s => s.StudentUserName == username))
                    {
                        if (Sdb.Students.Single(s => s.StudentUserName == username).StudentPwd == pwd)
                        {
                            return RedirectToAction("StudentMain");
                        }
                        else return Content("密码错误");
                    }
                    else return Content("用户不存在");
                }
            }
            else return null;  
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
                string uname = Request.Form["uname"];
                string pwd = Request.Form["pwd"];
                string name = Request.Form["name"];
                student.StudentUserName = uname;
                student.StudentPwd = pwd;
                student.Name = name;
                Sdb.Students.Add(student);
                Sdb.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(student);
        }
        /// <summary>
        /// 学生页面显示
        /// </summary>
        /// <returns></returns>
        public ActionResult StudentMain()
        {
            return View();
        }
    }
}
