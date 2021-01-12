using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectFinal.Models
{
    public class DataStatistic
    {
        public string ID { get; set; }
        public string TEN_CB { get; set; }
        public double GIA_TRI_CB { get; set; }
        public string THOI_GIAN { get; set; }

        public DataStatistic(string a, string b, double c, string d)
        {
            ID = a;
            TEN_CB = b;
            GIA_TRI_CB = c;
            THOI_GIAN = d;
        }
    }
}