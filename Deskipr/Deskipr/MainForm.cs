using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Subprojch;
using Subprojdb;
namespace Deskipr
{
    public partial class MainForm : Form
    {
        public static List<string> words = new List<string>();
        public static string word = "";
        public static List<string> wordas1 = new List<string>();
        public static List<string> wordas2 = new List<string>();
        public static List<string> wordas3 = new List<string>();
        public static List<string> wordas4 = new List<string>();
        public static List<string> wordas5 = new List<string>();
        public static List<string> checkas = new List<string>();
        public MainForm()
        {
            
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void EnterNewWord_Click(object sender, EventArgs e)
        {
            string word = textBox1.Text;
            word = word.Replace(" ", "");
            if (word != "")
            {
                Subprojdb.Dbase.Ewor(word, words);
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
            checkas.Clear();
            wordas1.Clear();
            wordas2.Clear();
            wordas3.Clear();
            wordas4.Clear();
            wordas5.Clear();
            Subprojdb.Dbase.Lastf(checkas,wordas1,wordas2,wordas3,wordas4,wordas5);
            comboBox1.Items.Clear();
            foreach (string check in checkas) comboBox1.Items.Add(check);
        }
    }
}
