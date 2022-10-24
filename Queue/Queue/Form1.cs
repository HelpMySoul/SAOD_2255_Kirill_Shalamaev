using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Queue
{
    public partial class Form1 : Form
    {
        NewQueue<string> mq;
        public Form1()
        {
            InitializeComponent();
            mq = new NewQueue<string>(8);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                mq.Enqueue(textBox1.Text);
            }
            catch (QueueExeption ne)
            {
                textBox1.Text = ne.Message;
            }
            
            UpdateText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = mq.Dequeue();
            }
            catch (QueueExeption ne)
            {
                textBox2.Text = ne.Message;
            }

            UpdateText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                textBox3.Text = mq.Peek();
            }
            catch (QueueExeption ne)
            {
                textBox3.Text = ne.Message;
            }

            UpdateText();
        }
        void UpdateText()
        {
            richTextBox1.Text = "";
            foreach (string s in mq.ToArray())
            {
                richTextBox1.Text += s + "\n";

            }
            richTextBox1.Text = richTextBox1.Text.Trim();
        }
    }
}
