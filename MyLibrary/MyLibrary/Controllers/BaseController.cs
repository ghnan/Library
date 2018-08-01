using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLibrary.Controllers
{
    public abstract class BaseController : Controller
    {
        public HttpSessionStateBase Session { get; }
    }
}