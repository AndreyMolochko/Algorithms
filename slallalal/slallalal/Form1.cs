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
            processingarr = new Processingarr();
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
                processingarr.FillAllData(c, a, b);
            }
               // label3.Text = textBoxComplex.Text + "  " + textBoxElements.Text + "  " + textBoxThreads.Text;
            else MessageBox.Show("Enter correct data!!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < processingarr.elements.Count; i++)
            {
                String str = "elements = " + processingarr.elements[i].ToString() +
                    " threads = " + processingarr.threads[i].ToString() +
                    "  complexity = " + processingarr.complex[i].ToString() +
                    "  timeSimpe = " + processingarr.timeSimple[i].ToString();
                //listBox1.Items.Add(str);
                if (radioButton3.Checked)
                {
                    this.chart1.Series["OneThread"].Points.AddXY(processingarr.elements[i].ToString(), processingarr.timeSimple[i]);
                    this.chart1.Series["MultiThreads"].Points.AddXY(processingarr.elements[i].ToString(), processingarr.timeMultiThreading[i]);
                }
                if (radioButton2.Checked)
                {
                    this.chart1.Series["OneThread"].Points.AddXY(processingarr.complex[i].ToString(), processingarr.timeSimple[i]);
                    this.chart1.Series["MultiThreads"].Points.AddXY(processingarr.complex[i].ToString(), processingarr.timeMultiThreading[i]);
                }
                if (radioButton1.Checked)
                {
                    this.chart1.Series["OneThread"].Points.AddXY(processingarr.threads[i].ToString(), processingarr.timeSimple[i]);
                    this.chart1.Series["MultiThreads"].Points.AddXY(processingarr.threads[i].ToString(), processingarr.timeMultiThreading[i]);
                }
            }
            //DrawCoordinates();
            //this.chart1.Series["OneThread"].Points.AddXY(processingarr.elements[0].ToString(),processingarr.timeSimple[0]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            processingarr.ClearData();
            //chart1.Series.Clear();
        }

        public void DrawCoordinates()
        {
            //PaintEventArgs paintEventArgs = new PaintEventArgs
            // Graphics gr = new Graphics();
            //Graphics graphics = pictureBox1.CreateGraphics();
            Pen blackPen = new Pen(Color.Black, 3);
            Point start = new Point(100, 100);
            Point x = new Point(100, processingarr.elements[0]+200);
            Point y = new Point(Convert.ToInt32(processingarr.timeSimple[0]), 100);
            //graphics.DrawLine(blackPen, start, x);
            //graphics.DrawLine(blackPen, start, y);
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.Series.Add("MultiThreads");
            chart1.Series.Add("OneThread");
        }
    }
}
