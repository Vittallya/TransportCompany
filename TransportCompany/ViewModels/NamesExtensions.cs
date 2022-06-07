using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportCompany.ViewModels
{
    public static class NamesExtensions
    {
        public static readonly Dictionary<ReportPeriod, string> PeriodNames = new Dictionary<ReportPeriod, string>
        {
            {ReportPeriod.Day, "День" },
            {ReportPeriod.Week, "Неделя" },
            {ReportPeriod.Month, "Месяц" },
            {ReportPeriod.Quartal, "Квартал" },
            {ReportPeriod.Year, "Год" },
        };
    }
}
