using System.Web.Mvc;

namespace MyLibrary.Student.Mvc
{
    public class StudentAreaRegistration : System.Web.Mvc.AreaRegistration
    {
        public override string AreaName => "Student";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(name: "StudentArea",
                url: "Student/{controller}/{action}/{id}",
                  defaults: new { area = "Student", controller = " Account", action = "Register", id = UrlParameter.Optional });
        }

    }
}
