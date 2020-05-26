using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Deskipr
{
    public partial class MainForm : Form
    {
        public static List<string> words = new List<string>();
        public static string word = "";
        public static string[] wordas1;
        public static string[] wordas2;
        public static string[] wordas3;
        public static string[] wordas4;
        public static string[] wordas5;
        public static string[] checkas;
        public MainForm()
        {
            
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

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

        private void EnterNewWord_Click(object sender, EventArgs e)
        {
            string word = textBox1.Text;
            word = word.Replace(" ", "");
            if (word != "")
            {
                Ewor(word, words);
                dataGridView1.Rows.Clear();
                dataGridView1.Visible = true;
                dataGridView1.Rows.Add(words.Count());
                for (int i = 0; i < words.Count(); i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = words[i];
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
            dataGridView2.Rows.Clear();
            if (comboBox1.SelectedIndex == 0) { 
                dataGridView2.Rows.Add(wordas1.Count());
                for(int i = 0; i < wordas1.Count(); i++)
                {
                    dataGridView2.Rows[i].Cells[0].Value = wordas1[i];
                }
            }
            if (comboBox1.SelectedIndex == 1)
            {
                dataGridView2.Rows.Add(wordas2.Count());
                for (int i = 0; i < wordas2.Count(); i++)
                {
                    dataGridView2.Rows[i].Cells[0].Value = wordas2[i];
                }
            }
            if (comboBox1.SelectedIndex == 2)
            {
                dataGridView2.Rows.Add(wordas3.Count());
                for (int i = 0; i < wordas3.Count(); i++)
                {
                    dataGridView2.Rows[i].Cells[0].Value = wordas3[i];
                }
            }
            if (comboBox1.SelectedIndex == 3)
            {
                dataGridView2.Rows.Add(wordas4.Count());
                for (int i = 0; i < wordas4.Count(); i++)
                {
                    dataGridView2.Rows[i].Cells[0].Value = wordas4[i];
                }
            }
            if (comboBox1.SelectedIndex == 4)
            {
                dataGridView2.Rows.Add(wordas5.Count());
                for (int i = 0; i < wordas5.Count(); i++)
                {
                    dataGridView2.Rows[i].Cells[0].Value = wordas5[i];
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lastf();
            comboBox1.Items.Clear();
            foreach (string check in checkas) comboBox1.Items.Add(check);
        }
    }
}
