using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using TransportCompany;

namespace TransportCompany.Controllers
{
    public class DriversController : Controller
    {
        private readonly DbContextLocal _context;
        private readonly Mapper map;

        public DriversController(DbContextLocal context, Mapper map)
        {
            _context = context;
            this.map = map;
        }

        // GET: Drivers
        public async Task<IActionResult> Index()
        {
            var dbContextLocal = _context.Drivers.Include(d => d.User);
            return View(await dbContextLocal.ToListAsync());
        }


        // GET: Transps/Details/5
        public async Task<IActionResult> Details(int? id, string backController = null, string backAction = null)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.BackController = backController ?? "Transps";
            ViewBag.BackAction = backAction ?? "Index";

            var transp = await _context.Drivers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transp == null)
            {
                return NotFound();
            }

            return View(transp);
        }

        // GET: Drivers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drivers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Driver driver)
        {
            if (CheckUserCreds(driver.User, out int? _))
            {
                ModelState.AddModelError("", "Логин и(или) пароль уже есть в бд");
            }
            else if (ModelState.IsValid)
            {
                driver.User.UserGroup = UserGroup.Driver;
                driver.User.Name = driver.Name;
                driver.IsDriverFree = true;
                _context.Add(driver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", driver.UserId);
            return View(driver);
        }

        private bool CheckUserCreds(User user, out int? sameId)
        {
            sameId = _context.Users.FirstOrDefault(x => x.Login.Equals(user.Login) || x.Password.Equals(user.Password))?.Id;
            return sameId.HasValue;
        }

        // GET: Drivers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", driver.UserId);
            return View(driver);
        }

        // POST: Drivers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Surname,Name,Otchestvo,Phone,Address,DriverCategory,IsDriverFree,UserId, User")] Driver driver)
        {
            if (id != driver.Id)
            {
                return NotFound();
            }
            else if(CheckUserCreds(driver.User, out int? uId) && uId.Value != driver.UserId)
            {
                ModelState.AddModelError("", "Логин и(или) пароль уже есть в бд");
            }
            else if (ModelState.IsValid)
            {
                try
                {
                    _context.ChangeTracker.Clear();
                    _context.Update(driver);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverExists(driver.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", driver.UserId);
            return View(driver);
        }

        // GET: Drivers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context.Drivers
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        // POST: Drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);
            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriverExists(int id)
        {
            return _context.Drivers.Any(e => e.Id == id);
        }
    }
}
