using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;

namespace TransportCompany.Controllers
{
    public class ContragentsController : Controller
    {
        private readonly DbContextLocal _context;

        public ContragentsController(DbContextLocal context)
        {
            _context = context;
        }

        // GET: Contragents
        public async Task<IActionResult> Index()
        {
            var dbContextLocal = _context.Contragents.Include(c => c.User);
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

            var transp = await _context.Contragents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transp == null)
            {
                return NotFound();
            }

            return View(transp);
        }

        // GET: Contragents/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Contragents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Country,GenDirector,Phone,Adres,UserId, User")] Contragent contragent)
        {

            if (CheckUserCreds(contragent.User, out int? _))
            {
                ModelState.AddModelError("", "Логин и(или) пароль уже есть в бд");
            }
            else if (ModelState.IsValid)
            {
                _context.Add(contragent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", contragent.UserId);
            return View(contragent);
        }

        private bool CheckUserCreds(User user, out int? v)
        {
            v = _context.Users.FirstOrDefault(x => x.Login.Equals(user.Login) || x.Password.Equals(user.Password))?.Id;
            return v.HasValue;
        }

        // GET: Contragents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contragent = await _context.Contragents.FindAsync(id);
            if (contragent == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", contragent.UserId);
            return View(contragent);
        }

        // POST: Contragents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Country,GenDirector,Phone,Adres,UserId, User")] Contragent contragent)
        {
            if (id != contragent.Id)
            {
                return NotFound();
            }

            else if (CheckUserCreds(contragent.User, out int? uId) && uId.Value != contragent.UserId)
            {
                ModelState.AddModelError("", "Логин и(или) пароль уже есть в бд");
            }
            else if (ModelState.IsValid)
            {
                try
                {
                    _context.ChangeTracker.Clear();
                    _context.Update(contragent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContragentExists(contragent.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", contragent.UserId);
            return View(contragent);
        }

        // GET: Contragents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contragent = await _context.Contragents
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contragent == null)
            {
                return NotFound();
            }

            return View(contragent);
        }

        // POST: Contragents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contragent = await _context.Contragents.FindAsync(id);
            _context.Contragents.Remove(contragent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContragentExists(int id)
        {
            return _context.Contragents.Any(e => e.Id == id);
        }
    }
}
