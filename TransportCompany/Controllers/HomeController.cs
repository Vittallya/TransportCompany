using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportCompany.Services;
using TransportCompany.ViewModels;

namespace TransportCompany.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbContextLocal db;
        private readonly UserService userService;
        private readonly Mapper _mapper;



        public HomeController(ILogger<HomeController> logger, DbContextLocal db, UserService userService, Mapper mapper)
        {
            _logger = logger;
            this.db = db;
            this.userService = userService;
            _mapper = mapper;
        }

        [Authorize]
        public IActionResult Index()
        {            
            return View();
        }
        [HttpGet]
        public IActionResult Reports()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Reports(ReportSettings reportSettings)
        {
            
            if(reportSettings.Period == ReportPeriod.Day)
            {
                return Json(GetDaysReport(reportSettings));
            }

            return Json(null);
        }

        private ReportData GetDaysReport(ReportSettings reportSettings)
        {
            var curDate = reportSettings.StartDate.Value.Date;
            var endDate = reportSettings.EndDate.Value.Date;

            var transits = db.Transits.
                Include(x => x.Transp).
                Where(x => x.DateCreat.Date >= curDate && x.DateCreat.Date <= endDate).
                AsEnumerable();

            int count = transits.Count();
            double totalDays = endDate.Subtract(curDate).TotalDays;


            var hashTable = transits.
                    GroupBy(y => y.DateCreat.Date).
                    ToDictionary(x => x.Key, y => y.ToList());

            List<string> labelsList = new List<string>();
            List<decimal> incomesList = new List<decimal>();
            List<decimal> outcomesList = new List<decimal>();
            List<decimal> profitList = new List<decimal>();


            decimal incomeTotal = 0;
            decimal profitTotal = 0;

            string format = "dd.MM.yy";

            while (curDate <= endDate)
            {                
                labelsList.Add(curDate.ToString(format));

                decimal income = 0;
                decimal outcome = 0;
                decimal profit = 0;

                if (hashTable.ContainsKey(curDate))
                {
                    var tr = hashTable[curDate];
                    income = tr.Sum(x => x.Income);
                    outcome = tr.Sum(x => x.Outcome);
                    profit = income - outcome;

                    incomeTotal += income;
                    profitTotal += profit;
                }
                incomesList.Add(income);
                outcomesList.Add(outcome);
                profitList.Add(profit);

                var temp = curDate.AddDays(1);

                format = "dd";

                if (temp.Month != curDate.Month)
                {
                    format += ".MM";

                    if (temp.Year != curDate.Year)
                        format += ".yy";
                }
                curDate = temp;
            }


            decimal efficiencyPercent = incomeTotal > 0 ? profitTotal / incomeTotal * 100 : 0;
            string[] labels = labelsList.ToArray();
            decimal[] incomes = incomesList.ToArray();
            decimal[] outcomes = outcomesList.ToArray();
            decimal[] profits = profitList.ToArray();
            decimal midSell = count / Convert.ToDecimal(totalDays);

            return new ReportData
            {
                Labels = labels,
                Efficiency = efficiencyPercent,
                Incomes = incomes,
                Outcomes = outcomes,
                Profits = profits,
                MidSell = midSell
            };
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
