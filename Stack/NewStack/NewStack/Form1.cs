using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewStack
{
    public partial class Form1 : Form
    {
        MyStack<string> ms;
        public Form1()
        {
            InitializeComponent();
            ms = new MyStack<string>(8);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ms.Push(textBox1.Text);
                UpdateText();
            }
            catch
            {
                textBox1.Text = "Ошибка";
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = ms.Pop();
                UpdateText();
            }
            catch
            {
                textBox2.Text = "Ошибка";
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
             try
            {
                textBox3.Text = ms.Top();
                UpdateText();
            }
            catch
            {
                textBox3.Text = "Ошибка";
            }
        }
        void UpdateText()
        {
            richTextBox1.Text = "";
            foreach( string s in ms.ToArray())
            {
                richTextBox1.Text += s + "\n";
                
            }
            richTextBox1.Text = richTextBox1.Text.Trim();
        }
        
    }
}
