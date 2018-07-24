using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyLibrary.Student.Mvc
{
    public class StudentAreaRegistration : System.Web.Mvc.AreaRegistration
    {
        public override string AreaName => "Student";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(name: "StudentArea",
                url: "{area}/{controller}/{action}/{id}",
                  defaults: new { area = "Student", controller = " Account", action = "Test", id = UrlParameter.Optional });

        }

    }
}
