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
    public partial class SortTask : Form
    {
        Random rnd = new Random();
        NewList<int> MyList = new NewList<int>();

        public SortTask()
        {
            InitializeComponent(); 
            MyList.SortRule = (Node<int> now) => now.value < now.next.value;

            int i = 10;
            while (i != 0)
            {
                MyList.Append(i);
                i--;
            }

            RUpdate();
        }
        void RUpdate()
        {
            richTextBox1.Text = "";
            foreach (int s in MyList)
            {
                richTextBox1.Text += s.ToString() + "\n";
            }
        }
        


        private void button1_Click(object sender, EventArgs e)
        {
            
            MyList = MyList.FastSort();
            RUpdate();
            
        }
    }
}
