using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHall4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Admin()
        {
            return PartialView();
        }
        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize]//change to admin
        public ActionResult Admin()
        {
            return View();
        }

       

        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult Packages()
        {
            return View();
        }
    }
}