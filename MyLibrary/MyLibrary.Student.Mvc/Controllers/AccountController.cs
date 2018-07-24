using System.Web.Mvc;
using System.Linq;
using System.Net;
using System;

namespace MyLibrary.Student.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private MyLibrary.Student.Properties.StudentDBContext Sdb = new MyLibrary.Student.Properties.StudentDBContext();
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult doLogin(string username,string pwd)
        {
            string name = Request.Form["uname"];
            if (Sdb.Students.Any(s => s.StudentUserName == username))
            {
                if (Sdb.Students.Single(s => s.StudentUserName == username).StudentPwd == pwd)
                {
                    return Content("登录成功");
                }
                else return Content("密码错误");
                }
            else return Content("用户不存在");
        }
        public ActionResult Register() {
            return View();
        }
        [HttpPost]
        public ActionResult doRegister(Model.Entities.Student student)
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
        public ActionResult LoginJudge(Model.Entities.Student student) {
            return Content(Convert.ToString(student.StudentID));

        }
        public ActionResult StudentMain()
        {
            return null;
        }
    }
}
