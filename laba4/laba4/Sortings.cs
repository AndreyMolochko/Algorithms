﻿using System;
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
        int n = 10;
        public Sortings()
        {
            a = new int[n];
            b = new int[n];
            c = new int[n];
            FillDataArray(b);
            Output(b);
            CoutingSort(b, 0, 300);
            Console.WriteLine("_____________________");
            Output(b);
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
    }
}