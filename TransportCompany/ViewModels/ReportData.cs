using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace TransportCompany.ViewModels
{
    public class ReportData
    {
        public decimal[] Incomes { get; set; }
        public string[] Labels { get; set; }
        public decimal Efficiency { get; set; }
        public decimal[] Outcomes { get; set; }
        public decimal[] Profits { get; set; }
        public decimal MidSell { get; set; }

        public decimal IncomeTotal { get; set; }
        public decimal OutcomeTotal { get; set; }
        public decimal ProftTotal { get; set; }
        public int TotalCount { get; set; }
    }
}
