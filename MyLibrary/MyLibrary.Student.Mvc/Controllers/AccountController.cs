using System.Web.Mvc;
using System.Linq;
using System.Net;

namespace MyLibrary.Student.Mvc.Controllers
{
    public class AccountController : Controller

    {
        public ActionResult Test()
        {
            return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "uid,pwd")] MyLibrary.Model.Entities.Student student)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("home/Login");
            }
            return View(student);
        }
    }
}
