using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace laba3
{
    class Processingarr
    {    
        //public int complexity,numberThreads,dimension;
        Random rnd;
        public List<int> elements;
        public List<int> complex;
        public List<int> threads;
        public Thread [] tr;
        public List<string> timeMultiThreading;
        public List<string> timeSimple;
        int[] arr;
        double[] arrB;
        double[] arrC;
        /// <summary>
        /// 
        /// </summary>
        private volatile double[] _array;
        private volatile int _flag = 0;
        private volatile int iterator = 0;
        public List<Thread> Threads { get; set; }
        private double[] _backupArray;
        public Processingarr()
        {
            //this.complexity = complexity;
            //this.numberThreads = numberThreads;
            //this.dimension = dimension;
            elements = new List<int>();
            complex = new List<int>();
            threads = new List<int>();
            timeMultiThreading = new List<string>();
            timeSimple = new List<string>();
            rnd = new Random();
            Threads = new List<Thread>();
            //InitArr();
            //FillArrSimple(complexity);
        }
        public void InitArr()
        {
            for (int i = 0; i < arr.Length; i++)
            {                
                arr[i] = rnd.Next();
            }
        }

        public void FillAllData(int dimension,int complexity,int numberThreads)
        {
            arr = new int[dimension];
            arrB = new double[dimension];
            arrC = new double[dimension];
            InitArr();
            elements.Add(dimension);
            complex.Add(complexity);
            threads.Add(numberThreads);
            FillArrSimple(dimension,complexity);
            FillArrMultiThreading(dimension, complexity,numberThreads);

        }

        public void FillArrSimple(int dimension, int complexity)
        {            
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();
            for (int b = 0; b < 10; b++)
            {
                for (int i = 0; i < dimension; i++)
                    for (int j = 0; j < complexity; j++)
                        arrB[i] += Math.Pow(arr[i], 1.789);
            }
            myStopwatch.Stop();
            String time = myStopwatch.ElapsedMilliseconds.ToString();
            double answer = Convert.ToDouble(time);
            string retAmount = (answer / 10).ToString();
            timeSimple.Add(retAmount);
        }

        private void Run()
        {
            foreach (var thread in Threads)
            {
                thread.Start();
            }
            foreach (var thread in Threads)
            {
                thread.Join();
            }
        }

        public void FillArrMultiThreading(int dimension, int complexity, int numberThreads)
        {
            Threads.Clear();
            int z = 0;
            int flag = 0;
            double sum = 0;
            
                for (int i = 0; i < numberThreads; i++)
                {
                    Threads.Add(new Thread(() =>
                    {
                        int dataSize = arr.Length / numberThreads;
                        int skip = dataSize * z++;
                        for (int k = skip; k < dataSize + skip; k++)
                        {
                            System.Diagnostics.Stopwatch my = new System.Diagnostics.Stopwatch();
                            my.Start();
                            for (int j = 0; j < complexity; j++)
                            {                                
                                arrC[k] = Math.Pow(arr[k], 1.789);
                            }
                            my.Stop();
                            String str = my.ElapsedMilliseconds.ToString();
                            sum += Convert.ToDouble(str);
                        }
                        flag++;
                    }));
                }
            
            
            System.Diagnostics.Stopwatch myStopwatchThread = new System.Diagnostics.Stopwatch();
            myStopwatchThread.Start();            
                Run();        
            myStopwatchThread.Stop();
            String time = myStopwatchThread.ElapsedMilliseconds.ToString();
            //double answer = Convert.ToDouble(time);
            //string retAmount = (sum / complexity).ToString();
            timeMultiThreading.Add(time);
        }

        

        public void ClearData()
        {
            elements.Clear();
            complex.Clear();
            threads.Clear();
            timeMultiThreading.Clear();
            timeSimple.Clear();
        }
    }
}
