using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using System.Data.SqlClient;
using Subprojdb;

namespace Webipr.Controllers
{
    public class EwordController : Controller
    {
        public static List<string> words=new List<string>();
        public static string word="";
        public ActionResult Eword()
        {
            return View();
        }
        [HttpPost]  
        public ActionResult Eword(string word)
        {
            Subprojdb.Dbase.Ewor(word,words);
            return RedirectPermanent("/Eword/Ewordres");
        }
        public ActionResult Ewordres(string word)
        {
            return View(words);
        }
    }
}