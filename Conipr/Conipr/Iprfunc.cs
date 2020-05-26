using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conipr
{
    class Iprfunc
    {
        public static List<string> words = new List<string>();
        public static string word = "";
        public static string[] wordas1;
        public static string[] wordas2;
        public static string[] wordas3;
        public static string[] wordas4;
        public static string[] wordas5;
        public static string[] checkas;
        static void Main(string[] args)
        {
            word = "і";
            using (var db = new intershipEntities())
            {
                words.Clear();
                words = db.Database.SqlQuery<string>("Select Text from Words Inner Join Checks ON Checks.CId = Words.ChId Where Checks.Word = '" + word + "'").ToList();
            }
            if (words.Count() == 0) Console.WriteLine("Nothing to get");
            else
            foreach (string worda in words)
                {
                    Console.WriteLine(worda);
                }
                int cycle = 0;
            while (cycle != 3)
            {
                Console.WriteLine("Choose, what to do:");
                Console.WriteLine("1.Enter new word");
                Console.WriteLine("2.5 last requests");
                Console.WriteLine("3.Exit");
                cycle = Convert.ToInt32(Console.ReadLine());
                switch (cycle)
                {
                    case 1:
                        string word;
                        Console.Write("Enter the word:");
                        word = Console.ReadLine();
                        Ewor(word, words);
                        Console.WriteLine("All words, which you can make from the letters of entered word: ");
                        foreach (string wor in words)
                        {
                            Console.WriteLine(wor + ";");
                        }
                        break;
                    case 2:
                        Lastf();
                        for (int i = 0; i < checkas.Count(); i++)
                        {
                            Console.WriteLine("All words, which you can make from the letters of word " + Convert.ToString(checkas[i]));
                            if (i == 0) foreach (String wor in wordas1) Console.WriteLine(wor + ";");
                            if (i == 1) foreach (String wor in wordas2) Console.WriteLine(wor + ";");
                            if (i == 2) foreach (String wor in wordas3) Console.WriteLine(wor + ";");
                            if (i == 3) foreach (String wor in wordas4) Console.WriteLine(wor + ";");
                            if (i == 4) foreach (String wor in wordas5) Console.WriteLine(wor + ";");
                        }
                        break;
                }
            }
        }
        public static void Lastf()
        {
            int i = 0;
            List<string> words = new List<string>();
            using (var db = new intershipEntities())
            {
                var checks = db.Checks.SqlQuery("WITH SRC AS (SELECT TOP (5) * FROM intership.dbo.Checks ORDER BY CId DESC) SELECT * FROM SRC ORDER BY CId").ToList();
                if (checks != null && checks.Count() >= 3)
                {
                    checkas = new string[checks.Count()];
                    foreach (var check in checks)
                    {
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
                    Ewor("aaa", words);
                    wordas1 = new string[words.Count()];
                    foreach (string word in words)
                    {
                        wordas1[i] = word;
                        i++;
                    }
                    checkas[0] = "aaa";
                    i = 0;
                    Ewor("babab", words);
                    wordas2 = new string[words.Count()];
                    foreach (string word in words)
                    {
                        wordas2[i] = word;
                        i++;
                    }
                    checkas[1] = "babab";
                    i = 0;
                    Ewor("abcd", words);
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
        public static void Check(string word, List<string> words)
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
                Check(word, words);
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
