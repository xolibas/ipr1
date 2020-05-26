using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webipr.Models;

namespace Webipr.Controllers
{
    public class HomeController : Controller
    {
        intershipEntities db = new intershipEntities();
        public ActionResult Index()
        {
            IEnumerable<Check> checks = db.Checks;
            ViewBag.Checks = checks;
            return View();
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}