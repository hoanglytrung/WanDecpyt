using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WanDecpyt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;
            string path = "";

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                path = choofdlog.FileName;
                string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true           
            }
            string filename = Path.GetFileName(path);
            
            StreamReader sr = new StreamReader(path);

            List<string> _List = new List<string>();
            string a = "";
            while ((a = sr.ReadLine()) != null)
            {
                _List.Add(a);
                textBox2.Text += a + "\r\n";
            }

            string Decpt = "";
            foreach (string line in _List)
            {
                
                Decpt += Decrypt(line) + "\r\n";
                
            }

            using (StreamWriter sw = new StreamWriter(@"C:\" + filename + "_Decpted", true))
            {
                sw.Write(Decpt);
            }
            sr.Dispose();

            textBox1.Text = Decpt;

            using (StreamReader sr1 = new StreamReader(@"C:\" + filename + "_Decpted", true))
            {
                textBox2.Text = sr1.ReadToEnd();
            }
                
        }
        public string Decrypt(string text)
        {
            string Decpt = "";
            string s = text;

            if (text != null || text != "")
            {
                for (int i = 0; i < s.Length; i += 3)
                {
                    Decpt += Convert.ToChar(int.Parse(s[i].ToString()) * 100 + int.Parse(s[i + 1].ToString()) * 10 + int.Parse(s[i + 2].ToString()));
                }
            }
            return Decpt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
