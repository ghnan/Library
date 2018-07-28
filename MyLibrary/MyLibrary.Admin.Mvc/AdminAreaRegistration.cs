using System.Web.Mvc;

namespace MyLibrary.Admin.Mvc
{
    public class AdminAreaRegistration : System.Web.Mvc.AreaRegistration
    {
        public override string AreaName => "Admin";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(name: "AdminArea",
                url: "Admin/{controller}/{action}/{id}",
                defaults: new { area = "Admin", controller = "DoAdmin", action = "AdminMain", id = UrlParameter.Optional });
        }
    }
}
