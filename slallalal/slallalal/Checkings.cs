using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    class Checkings
    {
        public Checkings()
        {

        }

        public bool IsntEmptyStrings(string a, string b, string c)
        {
            if (a != "" && b != "" && c != "") return true;
            else return false;
        }

        public bool isInt(string a,string b, string c)
        {
            //int flag;
            try
            {
                Convert.ToInt32(a);
                Convert.ToInt32(b);
                Convert.ToInt32(c);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
    }
}
