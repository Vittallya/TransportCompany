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

                return View("ChooseRoute", new TransitViewModel 
                { 
                    Transit = new Transit { DateCreat = DateTime.Now, GruzId = gruz.Id, TranspId = vehicle.Id},
                    Transp = vehicle, 
                    Routes = db.Routes.ToList(),
                    Drivers = db.Drivers.Where(x => x.IsDriverFree).ToList(),
                    Contragents = db.Contragents.ToList()
                });
            }

            ModelState.AddModelError("","Машина не найдена");
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> ChooseRoute(TransitViewModel model)
        {
            db.Add(model.Transit);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
