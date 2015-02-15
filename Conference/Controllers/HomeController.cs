using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conference.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Welcome()
		{
			ViewBag.Name = Session["Name"];
			return View("Welcome");
		}

		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult StoreName(String name)
		{
			Session["Name"] = name;
			return RedirectToAction("Welcome");
		}
    }
}
