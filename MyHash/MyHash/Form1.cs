using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHash
{
    public partial class Form1 : Form
    {
        MyHash<decimal, string> Hash = new MyHash<decimal, string>(8);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hash.Add(numericUpDown1.Value, textBox1.Text);
            UpdateHash();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = Hash.Find(numericUpDown2.Value).Value;
            }
            catch (Exception eh)
            {
                textBox2.Text = eh.Message;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Hash.Delete(numericUpDown3.Value);
                textBox3.Text = "Удалено";
            }
            catch (Exception eh)
            {
                textBox3.Text = eh.Message;
            }
            UpdateHash();
        }
        void UpdateHash()
        {
            string result = "";
            foreach (var n in Hash.GetDic())
            {
                result += $"{n.Key} - key, {n.Value} - value" + "\n";
            }
            richTextBox1.Text = result;
            foreach (List<Node<decimal, string>> n in Hash)
            {
                foreach (Node<decimal, string> s in n)
                {
                    Console.WriteLine(s.Value);
                }
                
            }
        }

        
    }
}
