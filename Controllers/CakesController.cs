using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CakeApplication.Data;
using CakeApplication.Models;

namespace CakeApplication.Controllers
{
    public class CakesController : Controller
    {
        private readonly CakeApplicationContext _context;

        public CakesController(CakeApplicationContext context)
        {
            _context = context;
        }

        // GET: Cakes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cakes.ToListAsync());
        }

        // GET: Cakes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cakes = await _context.Cakes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cakes == null)
            {
                return NotFound();
            }

            return View(cakes);
        }

        // GET: Cakes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cakes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,OrderDate,Flavour,Price")] Cakes cakes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cakes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cakes);
        }

        // GET: Cakes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cakes = await _context.Cakes.FindAsync(id);
            if (cakes == null)
            {
                return NotFound();
            }
            return View(cakes);
        }

        // POST: Cakes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,OrderDate,Flavour,Price")] Cakes cakes)
        {
            if (id != cakes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cakes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CakesExists(cakes.Id))
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
            return View(cakes);
        }

        // GET: Cakes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cakes = await _context.Cakes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cakes == null)
            {
                return NotFound();
            }

            return View(cakes);
        }

        // POST: Cakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cakes = await _context.Cakes.FindAsync(id);
            if (cakes != null)
            {
                _context.Cakes.Remove(cakes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CakesExists(int id)
        {
            return _context.Cakes.Any(e => e.Id == id);
        }
    }
}
