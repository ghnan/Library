using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyLibrary.Borrowing.Mvc
{
    public class BorrowingAreaRegistration : System.Web.Mvc.AreaRegistration
    {
        public override string AreaName => "Borrowing";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(name: "BorrowingArea",
                url: "Borrowing/{controller}/{action}/{id}",
                defaults: new { area = "Borrowing", controller = "DoBorrowing", action = "Test", id = UrlParameter.Optional });
        }
    }
}
