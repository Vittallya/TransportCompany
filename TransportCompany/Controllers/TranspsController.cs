using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using TransportCompany;

namespace TransportCompany.Controllers
{
    public class TranspsController : Controller
    {
        private readonly DbContextLocal _context;

        public TranspsController(DbContextLocal context)
        {
            _context = context;
        }

        // GET: Transps
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transps.ToListAsync());
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

            var transp = await _context.Transps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transp == null)
            {
                return NotFound();
            }

            return View(transp);
        }

        // GET: Transps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mark,Number,LoadCapasity,Characteristics,TransportPurpose,IsSpecial,TransportSpecialPurpose,Cost,PayToDriver,IsFree")] Transp transp)
        {
            if (ModelState.IsValid)
            {
                transp.IsFree = true;
                _context.Add(transp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transp);
        }

        // GET: Transps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transp = await _context.Transps.FindAsync(id);
            if (transp == null)
            {
                return NotFound();
            }
            return View(transp);
        }

        // POST: Transps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, 
            [Bind("Id,Mark,Number,LoadCapasity,Characteristics,TransportPurpose,IsSpecial,TransportSpecialPurpose,Cost,PayToDriver,IsFree")] Transp transp)
        {
            if (id != transp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.ChangeTracker.Clear();
                    _context.Update(transp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TranspExists(transp.Id))
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
            return View(transp);
        }

        // GET: Transps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transp = await _context.Transps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transp == null)
            {
                return NotFound();
            }

            return View(transp);
        }

        // POST: Transps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transp = await _context.Transps.FindAsync(id);
            _context.Transps.Remove(transp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TranspExists(int id)
        {
            return _context.Transps.Any(e => e.Id == id);
        }
    }
}
