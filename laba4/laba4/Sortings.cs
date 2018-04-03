using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4
{
    class Sortings
    {
        int[] a;
        int[] b;
        int[] c;
        int n = 25000;
        public Sortings()
        {
            a = new int[n];
            b = new int[n];
            c = new int[n];
            FillDataArray(a);
            FillDataArray(b);
            FillDataArray(c);
            System.Diagnostics.Stopwatch myStopwatch1 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch myStopwatch2 = new System.Diagnostics.Stopwatch();
            System.Diagnostics.Stopwatch myStopwatch3 = new System.Diagnostics.Stopwatch();
            myStopwatch1.Start();
            Console.WriteLine(myStopwatch1.Elapsed);
            CoutingSort(a, 0, 300);
            myStopwatch1.Stop();
            Console.WriteLine(myStopwatch1.Elapsed);
            Console.WriteLine("________Selection___________");
            myStopwatch2.Start();
            Console.WriteLine(myStopwatch2.Elapsed);
            SelectionSort(a);
            myStopwatch2.Stop();
            Console.WriteLine(myStopwatch2.Elapsed);
            Console.WriteLine("_________Merge___________");
            myStopwatch3.Start();
            Console.WriteLine(myStopwatch3.Elapsed);
            a = MergeSort(a);
            myStopwatch3.Stop();
            Console.WriteLine(myStopwatch3.Elapsed);
            //a = MergeSort(a);
            //Console.WriteLine("___________");
            //Output(a);

        }
        public void FillDataArray(int []a)
        {
            Random rnd = new Random();
            for(int i = 0;i< a.Length; i++)
            {
                a[i] = rnd.Next(0, 300);
            }
        }
        public void Output(int []a)
        {
            for(int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
        }
        public void CoutingSort(int []arr,int min,int max)
        {
            int[] count = new int[max - min + 1];
            int z = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                count[arr[i] - min]++;
            }

            for (int i = min; i <= max; i++)
            {
                while (count[i - min]-- > 0)
                {
                    arr[z] = i;
                    z++;
                }
            }
        }
        public void SelectionSort(int[] arr)
        {
            int min, temp;
            int length = arr.Length;

            for (int i = 0; i < length - 1; i++)
            {
                min = i;

                for (int j = i + 1; j < length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    temp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = temp;
                }
            }
        }
        public static int[] MergeSort(int[] massive)
        {
            if (massive.Length == 1)
                return massive;
            int mid_point = massive.Length / 2;
            return Merge(MergeSort(massive.Take(mid_point).ToArray()), MergeSort(massive.Skip(mid_point).ToArray()));
        }
        public static int[] Merge(int[] mass1, int[] mass2)
        {
            int a = 0, b = 0;
            int[] merged = new int[mass1.Length + mass2.Length];
            for (int i = 0; i < mass1.Length + mass2.Length; i++)
            {
                if (b < mass2.Length && a < mass1.Length)
                    if (mass1[a] > mass2[b] && b < mass2.Length)
                        merged[i] = mass2[b++];
                    else
                        merged[i] = mass1[a++];
                else
                    if (b < mass2.Length)
                    merged[i] = mass2[b++];
                else
                    merged[i] = mass1[a++];
            }
            return merged;
        }
    }
}
