using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RepairServiceApp.Data;
using RepairServiceApp.Models;

namespace RepairServiceApp.Controllers
{
    public class MalfunctionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MalfunctionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Malfunctions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Malfunctions.ToListAsync());
        }

        // GET: Malfunctions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var malfunction = await _context.Malfunctions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (malfunction == null)
            {
                return NotFound();
            }

            return View(malfunction);
        }

        // GET: Malfunctions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Malfunctions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderId,Description")] Malfunction malfunction)
        {
            if (ModelState.IsValid)
            {
                malfunction.Id = Guid.NewGuid();
                _context.Add(malfunction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(malfunction);
        }

        // GET: Malfunctions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var malfunction = await _context.Malfunctions.FindAsync(id);
            if (malfunction == null)
            {
                return NotFound();
            }
            return View(malfunction);
        }

        // POST: Malfunctions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,OrderId,Description")] Malfunction malfunction)
        {
            if (id != malfunction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(malfunction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MalfunctionExists(malfunction.Id))
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
            return View(malfunction);
        }

        // GET: Malfunctions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var malfunction = await _context.Malfunctions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (malfunction == null)
            {
                return NotFound();
            }

            return View(malfunction);
        }

        // POST: Malfunctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var malfunction = await _context.Malfunctions.FindAsync(id);
            if (malfunction != null)
            {
                _context.Malfunctions.Remove(malfunction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MalfunctionExists(Guid id)
        {
            return _context.Malfunctions.Any(e => e.Id == id);
        }
    }
}
