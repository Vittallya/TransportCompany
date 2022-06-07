using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TransportCompany.Services;
using TransportCompany.ViewModels;
using System.IO;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace TransportCompany.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbContextLocal db;
        private readonly Mapper _mapper;
        private readonly ExcelConverter converter;

        public HomeController(ILogger<HomeController> logger, DbContextLocal db, Mapper mapper, ExcelConverter converter)
        {
            _logger = logger;
            this.db = db;
            _mapper = mapper;
            this.converter = converter;
        }

        [Authorize]
        public IActionResult Index()
        {            
            return View();
        }
        [HttpGet]
        public IActionResult Reports()
        {
            return View(new ReportSettings {StartDate = DateTime.Now.AddDays(-15), EndDate = DateTime.Now, 
                StartYear = (short)(DateTime.Now.Year - 1), EndYear = (short)DateTime.Now.Year  });
        }

        [HttpPost]
        public IActionResult Reports(ReportSettings reportSettings)
        {            
            return Json(GetReport(reportSettings));
        }

        [HttpGet]
        public FileContentResult GetExcel(string data)
        {
            var dataSerialized = JsonConvert.DeserializeObject<ReportData>(data);   
            return File(converter.Convert(dataSerialized), "application/octet-stream", "Отчет.xlsx");
        }

        private ReportData GetReport(ReportSettings reportSettings)
        {
            DateTime curDate = default;
            DateTime endDate = default;

            var transits = db.Transits.AsEnumerable();

            List<string> labelsList = new List<string>();
            List<decimal> incomesList = new List<decimal>();
            List<decimal> outcomesList = new List<decimal>();
            List<decimal> profitList = new List<decimal>();

            decimal incomeTotal = 0;
            decimal profitTotal = 0;

            if (reportSettings.Period == ReportPeriod.Week)
            {
                curDate = GetDateFromStringWeek(reportSettings.StartWeek).AddDays(-6);
                endDate = GetDateFromStringWeek(reportSettings.EndWeek).AddDays(1).AddSeconds(-1);
                transits = transits.Where(x => x.DateCreat >= curDate && x.DateCreat <= endDate);
                var hashTable = transits.GroupBy(x => (GetWeekFormDate(x.DateCreat.Date), x.DateCreat.Year)).
                    ToDictionary(x => x.Key, y => y.AsEnumerable());

                IterateByPeriod(curDate, endDate, hashTable,
                    y => (GetWeekFormDate(y), y.Year),
                    y => y.AddDays(7),
                    (old, cur, init) =>
                    {
                        int week = GetWeekFormDate(cur);
                        string lb = week >= 10 ? week.ToString() : "0" + week;
                        if (cur.Year != old.Year || init)
                            lb += "." + cur.Year;

                        return lb;
                    }, labelsList, incomesList, outcomesList, profitList, out incomeTotal, out profitTotal);
            }
            else if(reportSettings.Period == ReportPeriod.Day)
            {
                curDate = reportSettings.StartDate.Value.Date;
                endDate = reportSettings.EndDate.Value.Date.AddDays(1).AddSeconds(-1);

                transits = transits.Where(x => x.DateCreat >= curDate && x.DateCreat <= endDate);
                var hashTable = transits.GroupBy(x => x.DateCreat.Date).
                    ToDictionary(x => x.Key, y => y.AsEnumerable());

                IterateByPeriod(curDate, endDate, hashTable,
                    y => y.Date,
                    y => y.AddDays(1),
                    (old, cur, init) =>
                    {
                        string lb = init ? "dd.MM.yy":"dd";

                        if (cur.Month != old.Month)
                        {
                            lb += ".MM";

                            if (old.Year != cur.Year)
                                lb += ".yy";
                        }

                        return cur.ToString(lb);
                    }, labelsList, incomesList, outcomesList, profitList, out incomeTotal, out profitTotal);

            }
            else if(reportSettings.Period == ReportPeriod.Month)
            {
                curDate = GetDateFromStringMonth(reportSettings.StartMonth);
                endDate = GetDateFromStringMonth(reportSettings.EndMonth).AddMonths(1).AddSeconds(-1);

                transits = transits.Where(x => x.DateCreat >= curDate && x.DateCreat <= endDate);
                var hashTable = transits.GroupBy(x => (x.DateCreat.Month, x.DateCreat.Year)).
                    ToDictionary(x => x.Key, y => y.AsEnumerable());

                IterateByPeriod(curDate, endDate, hashTable,
                    y => (y.Month, y.Year),
                    y => y.AddMonths(1),
                    (old, cur, init) => (old.Year == cur.Year && !init) ? cur.ToString("MMM") : cur.ToString("MMM.yy"),
                    labelsList, incomesList, outcomesList, profitList, out incomeTotal, out profitTotal);

            }
            else if(reportSettings.Period == ReportPeriod.Quartal)
            {
                string QuartalToRomeDigit(int d)
                {
                    if (d < 4)
                        return new string('I', d);
                    return "IV";
                }

                curDate = GetDateFromQuartal(reportSettings.QuartalStart, reportSettings.StartYear);
                endDate = GetDateFromQuartal(reportSettings.QuartalEnd, reportSettings.EndYear).AddMonths(3).AddSeconds(-1);

                transits = transits.Where(x => x.DateCreat >= curDate && x.DateCreat <= endDate);
                var hashTable = transits.GroupBy(x => (GetQuartalFromMonth(x.DateCreat.Month), x.DateCreat.Year)).
                    ToDictionary(x => x.Key, y => y.AsEnumerable());

                IterateByPeriod(curDate, endDate, hashTable,
                    y => (GetQuartalFromMonth(y.Month), y.Year),
                    y => y.AddMonths(3),
                    (old, cur, init) => 
                    {
                        string l = QuartalToRomeDigit(GetQuartalFromMonth(cur.Month));

                        if(old.Year != cur.Year || init)
                        {
                            l += "." + cur.Year;
                        }
                        return l;
                    },
                    labelsList, incomesList, outcomesList, profitList, out incomeTotal, out profitTotal);

            }

            else if(reportSettings.Period == ReportPeriod.Year)
            {

                curDate = new DateTime(reportSettings.StartYear, 1, 1);
                endDate = new DateTime(reportSettings.EndYear + 1, 1, 1).AddSeconds(-1);

                transits = transits.Where(x => x.DateCreat >= curDate && x.DateCreat <= endDate);
                var hashTable = transits.GroupBy(x => x.DateCreat.Year).
                    ToDictionary(x => x.Key, y => y.AsEnumerable());

                IterateByPeriod(curDate, endDate, hashTable,
                    y => y.Year,
                    y => y.AddYears(1),
                    (old, cur, init) => cur.ToString("yyyy"),
                    labelsList, incomesList, outcomesList, profitList, out incomeTotal, out profitTotal);

            }


            int count = transits.Count();
            double totalDays = endDate.Subtract(curDate).TotalDays;

            decimal efficiencyPercent = incomeTotal > 0 ? profitTotal / incomeTotal * 100 : 0;
            decimal midSell = incomeTotal / Convert.ToDecimal(totalDays);

            return new ReportData
            {
                Labels = labelsList.ToArray(),
                Efficiency = efficiencyPercent,
                Incomes = incomesList.ToArray(),
                Outcomes = outcomesList.ToArray(),
                Profits = profitList.ToArray(),
                MidSell = midSell,
                IncomeTotal = incomeTotal,
                OutcomeTotal = incomeTotal - profitTotal,
                ProftTotal = profitTotal,
                TotalCount = count
            };
        }

        private static void IterateByPeriod<TKey>(
                                            DateTime curDate,
                                            DateTime endDate,
                                            Dictionary<TKey, IEnumerable<Transit>> hashTable,
                                            Func<DateTime, TKey> keyGetter,
                                            Func<DateTime, DateTime> dateIterator,
                                            Func<DateTime, DateTime, bool, string> labelChanger,
                                            List<string> labelsList,
                                            List<decimal> incomesList,
                                            List<decimal> outcomesList,
                                            List<decimal> profitList,
                                            out decimal incomeTotal,
                                            out decimal profitTotal)
        {
            incomeTotal = profitTotal = 0;

            string label = labelChanger(curDate, curDate, true);

            while (curDate <= endDate)
            {
                labelsList.Add(label);

                decimal income = 0;
                decimal outcome = 0;
                decimal profit = 0;


                if (hashTable.ContainsKey(keyGetter(curDate)))
                {
                    var tr = hashTable[keyGetter(curDate)];
                    income = tr.Sum(x => x.Income);
                    outcome = tr.Sum(x => x.Outcome);
                    profit = income - outcome;

                    incomeTotal += income;
                    profitTotal += profit;
                }
                incomesList.Add(income);
                outcomesList.Add(outcome);
                profitList.Add(profit);

                var temp = dateIterator(curDate);

                label = labelChanger(curDate, temp, false);

                curDate = temp;
            }
        }




        DateTime GetDateFromStringWeek(string weekStr)
        {
            string[] arr = weekStr.Split('-');
            int year = int.Parse(arr[0]);
            int week = int.Parse(arr[1].Skip(1).ToArray());

            int days = week * 7;

            return new DateTime(year, 1, 1).AddDays(days + 1);
        }

        DateTime GetDateFromStringMonth(string monthStr)
        {
            string[] arr = monthStr.Split('-');
            int year = int.Parse(arr[0]);
            int month = int.Parse(arr[1].ToArray());

            return new DateTime(year, month, 1);
        }

        int GetQuartalFromMonth(int m)
        {
            return ((m - 1) / 3) + 1;
        }

        DateTime GetDateFromQuartal(int q, int year)
        {
            int m = ((q - 1) * 3) + 1;
            return new DateTime(year, m, 1);
        }

        public int GetWeekFormDate(DateTime date)
        {
            int days = date.DayOfYear;
            return (days + 4) / 7;
        }


        //[HttpGet]
        //public IActionResult UserCabinet(int? userId)
        //{
        //    if (!userId.HasValue)
        //        return RedirectToAction("Autorize");

        //    var user = db.Users.Find(userId);

        //    var model = _mapper.Map<User, UserViewModel>(user);
        //    model.Password = null;
        //    model.Login = null;



        //    if (model.UserGroup == UserGroup.Contragent)
        //        ViewData["Layout"] = "LayoutManager";
        //    else if (model.UserGroup == UserGroup.Driver)
        //        ViewData["Layout"] = "LayoutDriver";
        //    else if(model.UserGroup == UserGroup.Manager)
        //        ViewData["Layout"] = "LayoutManager";

        //    ViewBag.UserId = userId;
        //    return View(model);
        //}

    }
}
