using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace Webipr.Controllers
{
    public class FlreqController : Controller
    {
        public static string[] wordas1;
        public static string[] wordas2;
        public static string[] wordas3;
        public static string[] wordas4;
        public static string[] wordas5;
        public static string[] checkas;
        public ActionResult Flreq()
        {
            Lastf();
            ViewData["wordas1"] = wordas1;
            ViewData["wordas2"] = wordas2;
            ViewData["wordas3"] = wordas3;
            ViewData["wordas4"] = wordas4;
            ViewData["wordas5"] = wordas5;
            return View(checkas);
        }
        public static void Lastf()
        {
            int i = 0;
            List<string> words = new List<string>();
            using (var db = new intershipEntities())
            {
            var checks = db.Checks.SqlQuery("WITH SRC AS (SELECT TOP (5) * FROM intership.dbo.Checks ORDER BY CId DESC) SELECT * FROM SRC ORDER BY CId").ToList();
                if (checks != null && checks.Count()>=3)
                {
                    checkas = new string[checks.Count()];
                    foreach (var check in checks) {
                        checkas[i] = check.Word;
                        i++;
                    }
                    i = 0;
                    for (int j = 0; j < checkas.Length; j++)
                    {
                        var wordes = db.Words.SqlQuery("Select * from Words Inner Join Checks ON Checks.CId = Words.ChId Where Checks.Word = '" + checkas[j] + "'").ToList();
                            if (j == 0) wordas1 = new string[wordes.Count()];
                            if (j == 1) wordas2 = new string[wordes.Count()];
                            if (j == 2) wordas3 = new string[wordes.Count()];
                            if (j == 3) wordas4 = new string[wordes.Count()];
                            if (j == 4) wordas5 = new string[wordes.Count()];
                            foreach (var worde in wordes)
                            {
                                if (j == 0) wordas1[i] = Convert.ToString(worde.Text);
                                if (j == 1) wordas2[i] = Convert.ToString(worde.Text);
                                if (j == 2) wordas3[i] = Convert.ToString(worde.Text);
                                if (j == 3) wordas4[i] = Convert.ToString(worde.Text);
                                if (j == 4) wordas5[i] = Convert.ToString(worde.Text);
                                i++;
                            }
                            i = 0;
                    }
                }
                else
                {
                    checkas = new string[3];
                    EwordController.Ewor("aaa", words);
                    wordas1 = new string[words.Count()];
                    foreach(string word in words)
                    {
                        wordas1[i] = word;
                        i++;
                    }
                    checkas[0] = "aaa";
                    i = 0;
                    EwordController.Ewor("babab", words);
                    wordas2 = new string[words.Count()];
                    foreach (string word in words)
                    {
                        wordas2[i] = word;
                        i++;
                    }
                    checkas[1] = "babab";
                    i = 0;
                    EwordController.Ewor("abcd", words);
                    wordas3 = new string[words.Count()];
                    foreach (string word in words)
                    {
                        wordas3[i] = word;
                        i++;
                    }
                    checkas[2] = "abcd";
                    i = 0;
                }
            }
        }
    }
}