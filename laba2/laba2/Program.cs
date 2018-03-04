using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    class Program
    {
        static public int LinearSearch(int number,int []a)
        {
            for(int i = 0; i < a.Length; i++)
            {
                if (number.Equals(a[i])) return i;
            }
            return -1;
        }
        static public int BinarySearch(int number,int[] a)
        {
            Array.Sort(a);
            return Array.BinarySearch(a, number);
        }
        static int BinarySearchSecond(int number, int []array)
        {
            int left = 0;
            int right = array.Length;
            int i=0;
            while (left!=right)
            {
                i = left + (right - left) / 2;
                if (array[i] == number) return i;
                else
                {
                    if (array[i] > number) right = i;
                    else left = i + 1;
                    i = -1;
                }
            }            
            for(int j = 0; j < array.Length; j++)
            {
                if (number < array[j]) return -j - 1;
                else j++;                
            }
            return -array.Length - 1;
        }

        
        static void Main(string[] args)
        {
            
            int dimA = 500, dimB = 1000, dimC = 5000;
            int[] arrayA = new int[] { -7, 1, 3, 3, 4, 7, 11, 13 };
            int[] arrayB = new int[] { -7, 2, 2, 3, 4, 7, 8, 11, 13 };
            int[] arrayC = new int[] { -7, 1, 2, 3, 5, 7, 10, 13 };
            int[] a = new int[dimC];
            Exercise3 exercise = new Exercise3();
            Console.WriteLine(LinearSearch(7,arrayA));
            Console.WriteLine(BinarySearchSecond(8, arrayB));
            Console.WriteLine(BinarySearchSecond(8, arrayC));
            Console.WriteLine(exercise.First(a,dimC,4999));
            Console.WriteLine(exercise.Second(a, dimC, 4899));            
            Console.WriteLine(exercise.RecursSearch(a,0, dimC, 8));
            Console.ReadKey(true);
        }
    }
}
