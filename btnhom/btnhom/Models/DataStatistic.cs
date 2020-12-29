using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace btnhom.Models
{
    public class DataStatistic
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }

        public DataStatistic(string a,string b,string c,string d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }
    }
}