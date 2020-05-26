using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using System.Data.SqlClient;

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
            Ewor(word,words);
            return RedirectPermanent("/Eword/Ewordres");
        }
        public ActionResult Ewordres(string word)
        {
            return View(words);
        }
        //Function to find all words from the letters of entered word
        public static void Check(string word,List<string> words)
        {
            words.Clear();
            words.Add(word);
            string wr = word;
            bool iss;
            for (int i = 0; i < word.Length; i++)
                for (int j = 0; j < word.Length; j++)
                {
                    if (i != j)
                    {
                        iss = false;
                        StringBuilder sb = new StringBuilder(wr);
                        sb[i] = sb[j];
                        sb[j] = wr[i];
                        wr = sb.ToString();
                        foreach (string wor in words)
                        {
                            if (String.Compare(wor, wr) == 0) iss = true;
                        }
                        if (!iss)
                        {
                            words.Add(wr);
                            i = 0;
                            j = 0;
                        }
                    }
                }
        }

        public static void Ewor(string word, List<string> words)
        {
            using (var db = new intershipEntities())
            {
                Check(word,words);
                var wor = db.Database.ExecuteSqlCommand("INSERT INTO Checks (Word) VALUES ('"+word+"')");
                object wid = 0;
                Int64 ids = db.Database.SqlQuery<Int64>("SELECT CId From Checks Where Checks.Word='"+word+"'").FirstOrDefault();
                foreach (string wo in words)
                {
                    var ins = db.Database.ExecuteSqlCommand("INSERT INTO Words (Text,ChId) VALUES ('"+wo+"',"+ids+")");
                }
            }
        }
    }
}