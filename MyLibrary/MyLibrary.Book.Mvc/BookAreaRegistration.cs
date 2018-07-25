using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyLibrary.Book.Mvc
{
    public class BookAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Book";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(name: "BookArea",
                url: "Book/{controller}/{action}/{id}",
                  defaults: new { area = "Book", controller = "Book", action = "AddBook", id = UrlParameter.Optional });
        }

    }
}
