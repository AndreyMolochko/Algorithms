using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    class Exercise3
    {
        
        public Exercise3()
        {
            
        }
        public String First(int []array,int n,int x)
        {
            for(int i = 1; i < n; i++)
            {
                array[i] = i;
            }
            for(int i = 1; i < n; i++)
            {
                if (array[i].Equals(x)) return i.ToString();
            }
            return "Not-found";
        }
        public String Second(int[] array, int n, int x)
        {
            for (int j = 0; j < array.Length; j++)
            {
                array[j] = j;
            }
            int last = array[n-1];
            array[n-1] = x;
            int i = 1;
            while (array[i] != x)
                i++;
            array[n-1] = last;
            if (array[i] == x) return i.ToString();
            else return "not-found";
        }
        public String RecursSearch(int []array,int i,int last,int number)
        {
            Console.WriteLine(array[2000]);
            if (i == last) return "not-found";
            else
            {
                if (array[i].Equals(number)) return i.ToString();
                else RecursSearch(array, i + 1, last, number);                
                return "fdfdf";
            }
            
        }
    }
}
