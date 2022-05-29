using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportCompany.ViewModels;

namespace TransportCompany.Controllers
{
    public class TransitController : Controller
    {
        private readonly DbContextLocal db;

        public TransitController(DbContextLocal db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            var transits = await db.Transits.
                Include(x => x.Contragent).
                Include(x => x.Driver).
                Include(x => x.Route).
                Include(x => x.Transp).
                Include(x => x.Gruz).ToListAsync();


            var role = HttpContext.Request.Cookies["Role"]?.ToLower();
            var userId = int.Parse(HttpContext.Request.Cookies["UserId"]);

            if(!string.IsNullOrEmpty(role))
            {
                if (role == "driver")
                {
                    transits = transits.Where(y => y.Driver.UserId == userId).ToList();
                    return View("IndexDriver", transits);
                }
                else if(role == "contragent")
                {
                    transits = transits.Where(y => y.Contragent.UserId == userId).ToList();
                    return View("IndexContragent", transits);
                }
            }

            return View(transits);
        }

        public async Task<IActionResult> DriverAcceptTransit(int id)
        {
            var tr = await db.FindAsync<Transit>(id);
            tr.Status = TransitStatus.GivenToDriver;
            tr.DateDriverGiven = DateTime.Now;

            (await db.FindAsync<Transp>(tr.TranspId)).IsFree = false;
            (await db.FindAsync<Driver>(tr.DriverId)).IsDriverFree = false;
            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DriverExecutingTransit(int id, DateTime dateSend)
        {
            var tr = await db.FindAsync<Transit>(id);
            tr.Status = TransitStatus.Executing;
            tr.DateSend = DateTime.Now;
            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DriverCompleteTransit(int id, DateTime dateEnd)
        {
            var tr = await db.FindAsync<Transit>(id);
            tr.DateGetGruz = dateEnd;
            tr.Status = TransitStatus.Delivered;
            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> GruzDetails(int id)
        {
            var gruz = await db.FindAsync<Gruz>(id);
            return View(gruz);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Gruz gruz, bool isSpec, string purp = null, string purpSpec = null)
        {
            var vehicles = db.Transps.AsNoTracking().ToList().Where(x => x.IsFree && x.IsSpecial == isSpec);

            if(isSpec)
                vehicles = vehicles.Where(x => 
                x.TransportSpecialPurpose == Enum.Parse<TransportSpecialPurpose>(purpSpec));
            else
                vehicles = vehicles.Where(x =>
                x.TransportPurpose == Enum.Parse<TransportPurpose>(purp));

            var vehicle = vehicles.
                OrderBy(x => x.PayToDriver).
                ThenBy(x => x.Cost).
                FirstOrDefault(x => x.LoadCapasity >= gruz.Weight);

            if(vehicle != null)
            {
                db.Gruzs.Add(gruz);
                await db.SaveChangesAsync();
                return base.View("ChooseRoute", GetViewModel(gruz.Id, vehicle));
            }

            ModelState.AddModelError("","Машина не найдена");
            return View();
        }

        private TransitViewModel GetViewModel(int gruzId, Transp vehicle)
        {
            return new TransitViewModel
            {
                Transit = new Transit { DateCreat = DateTime.Now, GruzId = gruzId, TranspId = vehicle.Id },
                Transp = vehicle,
                Routes = db.Routes.ToList(),
                Drivers = db.Drivers.Where(x => x.IsDriverFree).ToList(),
                Contragents = db.Contragents.ToList()
            };
        }



        [HttpPost]
        public async Task <IActionResult> ChooseRoute(TransitViewModel model)
        {

            var transp = await db.FindAsync<Transp>(model.Transit.TranspId);

            if (model.IsNewContragent)
            {
                model.Transit.ContragentId = 0;
                model.Transit.Contragent = model.Contragent;

                if(string.IsNullOrEmpty(model.Contragent.User.Login) || string.IsNullOrEmpty(model.Contragent.User.Password))
                {
                    ModelState.AddModelError("", "Для контрагента необходимо ввести логин и пароль");
                    return View(GetViewModel(model.Transit.GruzId, transp));
                }

                else if(db.Users.Any(x => (x.Login == model.Contragent.User.Login || x.Password == model.Contragent.User.Password)))
                {
                    ModelState.AddModelError("", "Для контрагента такой логин и (-или) пароль уже существует");
                    return View(GetViewModel(model.Transit.GruzId, transp));
                }
                model.Contragent.User.UserGroup = UserGroup.Contragent;
            }

            var route = await db.FindAsync<Route>(model.Transit.RouteId);
            decimal hours = Convert.ToDecimal(route.HoursCount);

            model.Transit.Income = hours * transp.Cost;
            model.Transit.Outcome = hours * transp.PayToDriver;
            model.Transit.Profit = model.Transit.Income - model.Transit.Outcome;
            db.Update(model.Transit);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
