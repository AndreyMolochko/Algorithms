using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba4_OS
{
    public partial class Form1 : Form
    {
        Dictionary<string, int> timeProcG = new Dictionary<string, int>();
        Dictionary<string, int> timeProcRR = new Dictionary<string, int>();

        Dictionary<ComboBox, Label> timeInfo = new Dictionary<ComboBox, Label>();
        Dictionary<ComboBox, Label> priorInfo = new Dictionary<ComboBox, Label>();

        Dictionary<Label, ProgressBar> RRInfo = new Dictionary<Label, ProgressBar>();
        Dictionary<Label, ProgressBar> PriorInfoProgress = new Dictionary<Label, ProgressBar>();
        List<Task> tasks = new List<Task>();

        List<string> queueRR = new List<string>();
        List<string> queuePrior = new List<string>();
        List<int> priorClass = new List<int>();
        List<int> timeTas = new List<int>();
        List<int> spendTimeG = new List<int>();
        List<bool> isFinished = new List<bool>();

        List<Task> classes = new List<Task>();

        int numberProc;
        double promise;
        int timeAll;
        int curP;
        int prior = 10;

        public Form1()
        {
            InitializeComponent();
            string[] amount = { "3", "4", "5", "6", "7", "8", "9", "10" };
            comboBoxA.Items.AddRange(amount);
            comboBoxB.Items.AddRange(amount);
            comboBoxC.Items.AddRange(amount);
            comboBoxD.Items.AddRange(amount);
            comboBoxE.Items.AddRange(amount);
            comboBoxF.Items.AddRange(amount);
            comboBoxG.Items.AddRange(amount);
            comboBoxH.Items.AddRange(amount);
            comboBoxI.Items.AddRange(amount);
            comboBoxJ.Items.AddRange(amount);
        }

        private void butStart_Click(object sender, EventArgs e)
        {
            timeAll = 0;
            curP = -1;
            int j = 0;
            foreach (KeyValuePair<ComboBox, Label> pair in priorInfo)
            {
                if (j < numberProc)
                {                    
                    priorClass.Add(Convert.ToInt32(pair.Key.Text));                    
                }                
                j++;
            }
            j = 0;
            foreach (KeyValuePair<ComboBox, Label> pair in timeInfo)
            {
                if (j < numberProc)
                {            
                    timeTas.Add(Convert.ToInt32(pair.Key.Text));                    
                }
                j++;
            }
            try
            {
                int i = 0;
                foreach (KeyValuePair<ComboBox, Label> pair in timeInfo)
                {
                    if (i < numberProc)
                    {
                        int timeP = Int32.Parse(pair.Key.Text);
                        timeProcG.Add(pair.Value.Text, timeP);
                        timeProcRR.Add(pair.Value.Text, timeP);
                        tasks.Add(new Task(pair.Value.Text.ToString(),priorClass[i],timeTas[i]));
                        int a = 0;
                    }
                    i++;
                }
                button1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not all fields are filled");
                return;
            }

            int num = 0;
            int numForPrior;
            foreach (KeyValuePair<string, int> pair in timeProcRR)
            {
                num += pair.Value;
            }
            numForPrior = num;
            
            ////////////////////
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numberProc = 0;
            timeInfo.Add(timeA, A);
            timeInfo.Add(timeB, B);
            timeInfo.Add(timeC, C);
            timeInfo.Add(timeD, D);
            timeInfo.Add(timeE, E);
            timeInfo.Add(timeF, F);
            timeInfo.Add(timeG, G);
            timeInfo.Add(timeH, H);
            timeInfo.Add(timeI, I);
            timeInfo.Add(timeJ, J);

            priorInfo.Add(comboBoxA, A);
            priorInfo.Add(comboBoxB, B);
            priorInfo.Add(comboBoxC, C);
            priorInfo.Add(comboBoxD, D);
            priorInfo.Add(comboBoxE, E);
            priorInfo.Add(comboBoxF, F);
            priorInfo.Add(comboBoxG, G);
            priorInfo.Add(comboBoxH, H);
            priorInfo.Add(comboBoxI, I);
            priorInfo.Add(comboBoxJ, J);

            RRInfo.Add(RRA, progressBarA);
            RRInfo.Add(RRB, progressBarB);
            RRInfo.Add(RRC, progressBarC);
            RRInfo.Add(RRD, progressBarD);
            RRInfo.Add(RRE, progressBarE);
            RRInfo.Add(RRF, progressBarF);
            RRInfo.Add(RRG, progressBarG);
            RRInfo.Add(RRH, progressBarH);
            RRInfo.Add(RRI, progressBarI);
            RRInfo.Add(RRJ, progressBarJ);

            PriorInfoProgress.Add(GA, progressA);
            PriorInfoProgress.Add(GB, progressB);
            PriorInfoProgress.Add(GC, progressC);
            PriorInfoProgress.Add(GD, progressD);
            PriorInfoProgress.Add(GE, progressE);
            PriorInfoProgress.Add(GF, progressF);
            PriorInfoProgress.Add(GG, progressG);
            PriorInfoProgress.Add(GH, progressH);
            PriorInfoProgress.Add(GI, progressI);
            PriorInfoProgress.Add(GJ, progressJ);
        }

        private void numbProcesses_TextChanged(object sender, EventArgs e)
        {
            Int32.TryParse(numbProcesses.Text, out numberProc);
            int i = 0;
            queueRR.Clear();
            foreach (KeyValuePair<ComboBox, Label> pair in timeInfo)
            {
                if (i < numberProc)
                {
                    queueRR.Add(pair.Value.Text);
                    //priorClass.Add()
                    pair.Key.Visible = true;
                    pair.Value.Visible = true;
                    //timeTas.Add(Convert.ToInt32(pair.Key));
                    
                    //A.Visible = true;
                    

                    spendTimeG.Add(0);
                    isFinished.Add(false);
                }
                else
                {
                    pair.Key.Visible = false;
                    pair.Value.Visible = false;
                }
                i++;
            }

            queuePrior.Clear();
            i = 0;
            int[] amount = { 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (KeyValuePair<ComboBox, Label> pair in priorInfo)
            {
                if (i < numberProc)
                {
                    queuePrior.Add(pair.Value.Text);
                    pair.Key.Visible = true;
                    pair.Value.Visible = true;
                    //priorClass.Add(Convert.ToInt32(pair.Key));
                    //pair.Key.Items.Add(amount);

                    spendTimeG.Add(0);
                    isFinished.Add(false);
                }
                else
                {
                    pair.Key.Visible = false;
                    pair.Value.Visible = false;
                }
                i++;
            }

            i = 0;
            foreach (KeyValuePair<Label, ProgressBar> pair in RRInfo)
            {
                if (i < numberProc)
                {
                    pair.Key.Visible = true;
                    pair.Value.Visible = true;
                }
                else
                {
                    pair.Key.Visible = false;
                    pair.Value.Visible = false;
                }
                i++;
            }

            i = 0;
            foreach (KeyValuePair<Label, ProgressBar> pair in PriorInfoProgress)
            {
                if (i < numberProc)
                {
                    pair.Key.Visible = true;
                    pair.Value.Visible = true;
                }
                else
                {
                    pair.Key.Visible = false;
                    pair.Value.Visible = false;
                }
                i++;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            butStart.Visible = false;
            RoundRobin();
            Priorited();
        }

        private void RoundRobin()
        {
            while (queueRR.Count != 0)
            {
                string proc = queueRR[0];
                int number = timeProcRR[proc];
                foreach (KeyValuePair<Label, ProgressBar> pair1 in RRInfo)
                {
                    if (proc.Equals(pair1.Key.Text))
                    {
                        // ChangePlaces(pair1);
                        int answer;                        
                        int percent = 100 / timeProcRR[pair1.Key.Text];
                        answer = pair1.Value.Value + percent;
                        if (answer>100)
                        {
                            timeProcRR[proc] = --number;                       }
                        else
                        {
                            pair1.Value.Value += percent;
                            timeProcRR[proc] = --number;
                        }

                        queueRR.Remove(proc);
                        if (number == 0)
                        {
                            pair1.Value.Visible = false;
                            pair1.Key.Visible = false;
                        }
                        else
                            queueRR.Add(proc);
                        return;
                    }
                }
            }
        }
        

        private void Priorited()
        {
            //int prior = 10;
            if (classes.Count == 0)
            {
                bool flag = false;
                for(int i = 10; i >= 3; i--)
                {
                    for(int j = 0; j < tasks.Count; j++)
                    {
                        if (tasks[j].prior == i) classes.Add(tasks[j]);
                    }
                }
                
            }
            while (queuePrior.Count != 0)
            {
                string proc = classes[0].name;
                int number = timeProcG[proc];
                foreach (KeyValuePair<Label, ProgressBar> pair1 in PriorInfoProgress)
                {
                    if (proc.Equals(pair1.Key.Text))
                    {
                        int answer;
                        int percent = 100 / timeProcG[pair1.Key.Text];
                        answer = pair1.Value.Value + percent;
                        if (answer > 90)
                        {
                            timeProcG[proc] = --number;
                        }
                        else
                        {
                            pair1.Value.Value += percent;
                            timeProcG[proc] = --number;
                        }

                        queuePrior.Remove(proc);
                        if (number == 0)
                        {
                            pair1.Value.Visible = false;
                            pair1.Key.Visible = false;
                            classes.RemoveAt(0);
                            
                        }
                        else
                            queuePrior.Add(proc);
                        return;
                    }
                }
            }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (KeyValuePair<ComboBox, Label> pair in timeInfo)
            {
                if (i == numberProc)
                {
                    pair.Key.Visible = true;
                    pair.Value.Visible = true;
                    int timeP;
                    if (!Int32.TryParse(addProc.Text, out timeP))
                        timeP = 3;
                    pair.Key.Text = timeP.ToString();
                    queueRR.Add(pair.Value.Text);
                    timeProcRR.Add(pair.Value.Text, timeP);
                    timeProcG.Add(pair.Value.Text, timeP);
                }
                i++;
            }

            i = 0;
            foreach (KeyValuePair<Label, ProgressBar> pair in RRInfo)
            {
                if (i == numberProc)
                {
                    pair.Key.Visible = true;
                    pair.Value.Visible = true;
                }
                i++;
            }

            i = 0;
            foreach (KeyValuePair<Label, ProgressBar> pair in PriorInfoProgress)
            {
                if (i == numberProc)
                {
                    pair.Key.Visible = true;
                    pair.Value.Visible = true;
                    curP = -1;
                }
                i++;
            }

            spendTimeG.Add(0);
            isFinished.Add(false);

            int k = 0;
            foreach (bool fin in isFinished)
            {
                if (!fin)
                    k++;
            }
            if (k == 0)
                promise = 0;
            else
                promise = timeAll * 1.0 / k;
            //prom.Text = promise.ToString();

            numberProc++;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void progressBarB_Click(object sender, EventArgs e)
        {

        }

        private void RRB_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
