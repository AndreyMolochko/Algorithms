using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba3
{
    public partial class Form1 : Form
    {
        Processingarr processingarr;
        Checkings checkings;
        public Form1()
        {
            InitializeComponent();
            checkings = new Checkings();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkings.IsntEmptyStrings(textBoxComplex.Text, textBoxElements.Text, textBoxThreads.Text) &&
                checkings.isInt(textBoxComplex.Text, textBoxElements.Text, textBoxThreads.Text))
            {
                int a, b, c;
                a = Convert.ToInt32(textBoxComplex.Text);
                b = Convert.ToInt32(textBoxThreads.Text);
                c = Convert.ToInt32(textBoxElements.Text);
                processingarr = new Processingarr(a, b, c);
            }
               // label3.Text = textBoxComplex.Text + "  " + textBoxElements.Text + "  " + textBoxThreads.Text;
            else MessageBox.Show("Enter correct data!!!");
        }
    }
}
