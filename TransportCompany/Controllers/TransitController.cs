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
            return View(await db.Transits.ToListAsync());
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

            if(model.IsNewContragent)
            {
                model.Transit.ContragentId = 0;
                model.Transit.Contragent = model.Contragent;

                if(string.IsNullOrEmpty(model.Contragent.User.Login) || string.IsNullOrEmpty(model.Contragent.User.Password))
                {
                    ModelState.AddModelError("", "Для контрагента необходимо ввести логин и пароль");
                    return View(GetViewModel(model.Transit.GruzId, await db.FindAsync<Transp>(model.Transit.TranspId)));
                }

                else if(db.Users.Any(x => (x.Login == model.Contragent.User.Login || x.Password == model.Contragent.User.Password)))
                {
                    ModelState.AddModelError("", "Для контрагента такой логин и (-или) пароль уже существует");
                    return View(GetViewModel(model.Transit.GruzId, await db.FindAsync<Transp>(model.Transit.TranspId)));
                }
                model.Contragent.User.UserGroup = UserGroup.Contragent;
            }

            db.Update(model.Transit);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
