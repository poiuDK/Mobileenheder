using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Mobileenheder.Data
{
    public class cmdbsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public cmdbsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: cmdbs
        public async Task<IActionResult> Index()
        {
            return View(await _context.cmdbs.ToListAsync());
        }

        // GET: cmdbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cmdb = await _context.cmdbs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cmdb == null)
            {
                return NotFound();
            }

            return View(cmdb);
        }

        // GET: cmdbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cmdbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,InStock")] cmdb cmdb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cmdb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cmdb);
        }

        // GET: cmdbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cmdb = await _context.cmdbs.FindAsync(id);
            if (cmdb == null)
            {
                return NotFound();
            }
            return View(cmdb);
        }

        // POST: cmdbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,InStock")] cmdb cmdb)
        {
            if (id != cmdb.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cmdb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cmdbExists(cmdb.ID))
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
            return View(cmdb);
        }

        // GET: cmdbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cmdb = await _context.cmdbs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cmdb == null)
            {
                return NotFound();
            }

            return View(cmdb);
        }

        // POST: cmdbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cmdb = await _context.cmdbs.FindAsync(id);
            _context.cmdbs.Remove(cmdb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cmdbExists(int id)
        {
            return _context.cmdbs.Any(e => e.ID == id);
        }
    }
}
