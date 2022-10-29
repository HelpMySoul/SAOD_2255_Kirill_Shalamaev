using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTree
{
    public partial class Form1 : Form
    {
        BinTree<int> MyTree = new BinTree<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyTree.Insert(Convert.ToInt32(numericUpDown1.Value));
            if (MyTree.Count != 0)
            {
                richTextBox1.Text = MyTree.Show();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MyTree.Count != 0)
            {
            try
            {
                textBox1.Text = MyTree.Find(Convert.ToInt32(textBox1.Text)).ToString();
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
            }
            
                richTextBox1.Text = MyTree.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyTree.Delete(Convert.ToInt32(numericUpDown2.Value));
            if (MyTree.Count != 0)
            {
                richTextBox1.Text = MyTree.Show();
            }
        }
    }
}
