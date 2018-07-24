using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using System.Net;
using MyLibrary.Student.Properties;

namespace MyLibrary.Student.Controllers
{
    public class AccountController : Controller

    {
        public ActionResult Test()
        {
            return null;
        }

        private StudentDBContext db = new StudentDBContext();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "uid,pwd")] MyLibrary.Model.Entities.Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("home/Login");
            }
            return View(student);
        }
    }
}
