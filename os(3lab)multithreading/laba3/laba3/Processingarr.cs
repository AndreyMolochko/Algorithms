using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    class Processingarr
    {    
        public int complexity,numberThreads,dimension;
        public Processingarr(int complexity,int numberThreads, int dimension)
        {
            this.complexity = complexity;
            this.numberThreads = numberThreads;
            this.dimension = dimension;
        }
    }
}
