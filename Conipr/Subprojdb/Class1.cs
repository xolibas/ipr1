using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subprojch;

namespace Subprojdb
{
    public class Dbase
    {
        public static void Lastf(List<string> checkas, List<string> wordas1, List<string> wordas2, List<string> wordas3, List<string> wordas4, List<string> wordas5)
        {
            List<string> words = new List<string>();
            using (var db = new intershipEntities())
            {
                var checks = db.Checks.SqlQuery("WITH SRC AS (SELECT TOP (5) * FROM intership.dbo.Checks ORDER BY CId DESC) SELECT * FROM SRC ORDER BY CId").ToList();
                if (checks != null && checks.Count() >= 3)
                {
                    foreach (var check in checks) checkas.Add(check.Word);
                    for (int j = 0; j < checkas.Count(); j++)
                    {
                        var wordes = db.Words.SqlQuery("Select * from Words Inner Join Checks ON Checks.CId = Words.ChId Where Checks.Word = '" + checkas[j] + "'").ToList();
                        foreach (var worde in wordes)
                        {
                            if (j == 0) wordas1.Add(Convert.ToString(worde.Text));
                            if (j == 1) wordas2.Add(Convert.ToString(worde.Text));
                            if (j == 2) wordas3.Add(Convert.ToString(worde.Text));
                            if (j == 3) wordas4.Add(Convert.ToString(worde.Text));
                            if (j == 4) wordas5.Add(Convert.ToString(worde.Text));
                        }
                    }
                }
                else
                {
                    Ewor("aaa", words);
                    foreach (string word in words)
                    {
                        wordas1.Add(word);
                    }
                    checkas.Add("aaa");
                    Ewor("babab", words);
                    foreach (string word in words)
                    {
                        wordas2.Add(word);
                    }
                    checkas.Add("babab");
                    Ewor("abcd", words);
                    foreach (string word in words)
                    {
                        wordas3.Add(word);
                    }
                    checkas.Add("abcd");
                }
            }
        }
        public static void Ewor(string word, List<string> words)
        {
            using (var db = new intershipEntities())
            {
                Subprojch.Words.Check(word, words);
                var wor = db.Database.ExecuteSqlCommand("INSERT INTO Checks (Word) VALUES ('" + word + "')");
                object wid = 0;
                Int64 ids = db.Database.SqlQuery<Int64>("SELECT CId From Checks Where Checks.Word='" + word + "'").FirstOrDefault();
                foreach (string wo in words)
                {
                    var ins = db.Database.ExecuteSqlCommand("INSERT INTO Words (Text,ChId) VALUES ('" + wo + "'," + ids + ")");
                }
            }
        }
    }
}
