using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompany.ViewModels
{
    public enum ReportPeriod
    {
        Day, Week, Month, Quartal, Year
    }

    public class ReportSettings
    {


        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public short StartYear { get; set; }
        public short EndYear { get; set; }
        public string StartMonth { get; set; }
        public string EndMonth { get; set; }
        public string StartWeek { get; set; }
        public string EndWeek { get; set; }
        public byte QuartalStart { get; set; }
        public byte QuartalEnd { get; set; }

        /// <summary>
        /// false - первое полугодие, true - второе полугодие
        /// </summary>
        public bool HalfYear { get; set; }
        public ReportPeriod Period { get; set; }
    }
}
