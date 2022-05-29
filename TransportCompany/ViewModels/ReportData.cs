using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompany.ViewModels
{
    public class ReportData
    {
        public decimal[] Incomes { get; set; }

        public string[] Labels { get; set; }
        public float[] Values { get; set; }
        public decimal Efficiency { get; internal set; }
        public decimal[] Outcomes { get; internal set; }
        public decimal[] Profits { get; internal set; }
        public decimal MidSell { get; internal set; }
    }
}
