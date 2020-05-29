using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subprojdb;

namespace Conipr
{
    class Iprfunc
    {
        public static List<string> words = new List<string>();
        public static string word = "";
        public static List<string> wordas1 = new List<string>();
        public static List<string> wordas2 = new List<string>();
        public static List<string> wordas3 = new List<string>();
        public static List<string> wordas4 = new List<string>();
        public static List<string> wordas5 = new List<string>();
        public static List<string> checkas = new List<string>();
        static void Main(string[] args)
        {
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
                        Subprojdb.Dbase.Ewor(word, words);
                        Console.WriteLine("All words, which you can make from the letters of entered word: ");
                        foreach (string wor in words)
                        {
                            Console.WriteLine(wor + ";");
                        }
                        break;
                    case 2:
                        Subprojdb.Dbase.Lastf(checkas,wordas1,wordas2,wordas3,wordas4,wordas5);
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
    }
}
