using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dormitory.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Menu()
        {
            return View();
        }

    }
}
