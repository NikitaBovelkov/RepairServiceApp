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
    public class OrderExecutionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderExecutionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrderExecutions
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrderExecutions.ToListAsync());
        }

        // GET: OrderExecutions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderExecution = await _context.OrderExecutions
                .FirstOrDefaultAsync(m => m.ExecutionId == id);
            if (orderExecution == null)
            {
                return NotFound();
            }

            return View(orderExecution);
        }

        // GET: OrderExecutions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderExecutions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExecutionId,OrderId,EmployeeId,RepairType,RepairCost,ExecutionDate,Notification,ProductGet,TotalCost")] OrderExecution orderExecution)
        {
            if (ModelState.IsValid)
            {
                orderExecution.ExecutionId = Guid.NewGuid();
                _context.Add(orderExecution);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderExecution);
        }

        // GET: OrderExecutions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderExecution = await _context.OrderExecutions.FindAsync(id);
            if (orderExecution == null)
            {
                return NotFound();
            }
            return View(orderExecution);
        }

        // POST: OrderExecutions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ExecutionId,OrderId,EmployeeId,RepairType,RepairCost,ExecutionDate,Notification,ProductGet,TotalCost")] OrderExecution orderExecution)
        {
            if (id != orderExecution.ExecutionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderExecution);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExecutionExists(orderExecution.ExecutionId))
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
            return View(orderExecution);
        }

        // GET: OrderExecutions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderExecution = await _context.OrderExecutions
                .FirstOrDefaultAsync(m => m.ExecutionId == id);
            if (orderExecution == null)
            {
                return NotFound();
            }

            return View(orderExecution);
        }

        // POST: OrderExecutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var orderExecution = await _context.OrderExecutions.FindAsync(id);
            if (orderExecution != null)
            {
                _context.OrderExecutions.Remove(orderExecution);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExecutionExists(Guid id)
        {
            return _context.OrderExecutions.Any(e => e.ExecutionId == id);
        }
    }
}
