using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Subprojch
{
    public class Words
    {
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
    }
}
