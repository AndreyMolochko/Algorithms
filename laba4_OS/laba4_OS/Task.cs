using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4_OS
{
    class Task
    {
        public string name;
        public int prior;
        public int quantTime;
        public int counter;
        public Task(string name, int prior, int quantTime)
        {
            this.name = name;
            this.prior = prior;
            this.quantTime = quantTime;
            counter = 0;
        }
    }
}
