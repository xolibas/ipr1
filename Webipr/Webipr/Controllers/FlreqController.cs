using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Subprojdb;

namespace Webipr.Controllers
{
    public class FlreqController : Controller
    {
        public static List<string> wordas1 = new List<string>();
        public static List<string> wordas2 = new List<string>();
        public static List<string> wordas3 = new List<string>();
        public static List<string> wordas4 = new List<string>();
        public static List<string> wordas5 = new List<string>();
        public static List<string> checkas = new List<string>();
        public ActionResult Flreq()
        {
            checkas.Clear();
            wordas1.Clear();
            wordas2.Clear();
            wordas3.Clear();
            wordas4.Clear();
            wordas5.Clear();
            Subprojdb.Dbase.Lastf(checkas,wordas1,wordas2,wordas3,wordas4,wordas5);
            ViewData["wordas1"] = wordas1;
            ViewData["wordas2"] = wordas2;
            ViewData["wordas3"] = wordas3;
            ViewData["wordas4"] = wordas4;
            ViewData["wordas5"] = wordas5;
            return View(checkas);
        }
    }
}