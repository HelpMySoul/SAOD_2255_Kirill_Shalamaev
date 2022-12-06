using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewList
{
    public partial class Form1 : Form
    {
        NewList<string> MyList = new NewList<string>();
        public Form1()
        {
            InitializeComponent();
            MyList.SortRule = (Node<string> now) => now.value.Length > now.next.value.Length;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MyList.Append(textBox1.Text);
            }
            catch (ListExeption le)
            {
                textBox1.Text = le.Message;
            }

            //MyList[0] = "1";  // можно использовать индексаторы
            RUpdate();
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MyList.Prepend(textBox2.Text);
            }
            catch (ListExeption le)
            {
                textBox2.Text = le.Message;
            }

            RUpdate();
        }
        void RUpdate()
        {
            richTextBox1.Text = "";
            foreach (string s in MyList)
            {
                richTextBox1.Text += s + "\n";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MyList.Insert(Convert.ToInt32(numericUpDown1.Value), textBox4.Text);
            }
            catch (ListExeption le)
            {
                textBox4.Text = le.Message;
            }

            RUpdate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MyList.Remove(textBox5.Text);
            }
            catch (ListExeption le)
            {
                textBox5.Text = le.Message;
            }
            RUpdate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                MyList.RemoveAt(Convert.ToInt32(numericUpDown2.Value));
            }
            catch (ListExeption le)
            {
                textBox3.Text = le.Message;
            }
            RUpdate();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                textBox8.Text = MyList.FindRef(textBox7.Text);
            }
            catch (ListExeption le)
            {
                textBox8.Text = le.Message;
            }
            RUpdate();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                textBox10.Text = MyList.FindId(Convert.ToInt32(numericUpDown3.Value));
            }
            catch (ListExeption le)
            {
                textBox10.Text = le.Message;
            }
            RUpdate();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            MyList.Sort();
            RUpdate();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SortTask sortTask = new SortTask();
            sortTask.Show();
        }
    }
}
