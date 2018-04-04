using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba2
{
    public partial class Form1 : Form
    {
        int n = 5;        
        bool[] amounts = { false, false };
        int turn = 0;
        //bool start;
        void enter_region(int process)
        {
            amounts[process] = true;
            turn = process;
            listBox1.Items.Add("Process " + Convert.ToString(process) + " was entered to the critical region.");
        }

        void leave_region(int process)
        {
            amounts[process] = false;
            listBox1.Items.Add("Process " + Convert.ToString(process) + " left the critical region.");
        }
        public Form1()
        {            
            InitializeComponent();
            //start = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;

            if (amounts[1] && turn == 1)
            {
                listBox1.Items.Add("Waiting.");
            }
            else
            {
                enter_region(0);
                listBox1.Items.Add("The result of the process: " + Convert.ToString(FirstProcess(textBox1.Text)));//process 1
                leave_region(0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (amounts[0] && turn == 0)
            {
                listBox1.Items.Add("Waiting.");
            }
            else
            {
                enter_region(1);
                SecondProcess(n);
                listBox1.Items.Add("You should listen beep : ");//process2
                leave_region(1);

            }

        }
        public double FirstProcess(String number)
        {            
            double numberDouble = Convert.ToDouble(number);            
            return numberDouble*numberDouble;
        }

        public void SecondProcess(int n)
        {
            for(int i = 0; i < n; i++)
            {
                System.Console.Beep(500, 2000);
            }
        }
        

        public void noncritical_region()
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (turn == 0)
            {
                listBox1.Items.Add("The result of the process: " + Convert.ToString(FirstProcess(textBox1.Text)));
                turn = 1;
            }
            else
            {
                listBox1.Items.Add("Another process in the critical region.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (turn == 1)
            {
                SecondProcess(n);
                listBox1.Items.Add("You should listen beep : ");
                turn = 0;
            }
            else
            {
                listBox1.Items.Add("Another process in the critical region.");
            }
        }
    }
}
