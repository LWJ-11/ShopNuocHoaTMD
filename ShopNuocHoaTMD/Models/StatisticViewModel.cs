using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopNuocHoaTMD.Models
{
    public struct StatisticViewModel
    {
        public int Today { get; set; }
        public int Yesterday { get; set; }
        public int ThisWeek { get; set; }
        public int LastWeek { get; set; }
        public int ThisMonth { get; set; }
        public int LastMonth { get; set; }
        public int Total { get; set; }

    }
    public class StatisticModel
    {
        public string Today { get; set; }
        public string Yesterday { get; set; }
        public string ThisWeek { get; set; }
        public string LastWeek { get; set; }
        public string ThisMonth { get; set; }
        public string LastMonth { get; set; }
        public string Total { get; set; }

    }
}