using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using admininterface.Data;
using admininterface.Models;
using Microsoft.AspNetCore.Authorization;

namespace admininterface.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class TreatmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TreatmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Treatment
        public async Task<IActionResult> Index(string SearchString)
        {
             if(_context.Treatments == null)
            {
                return Problem("TreatmentContext.Treatment is null");
            }

            var treatment = from m in _context.Treatments.Include(b => b.TreatmentType)
                            select m;
            
            if(!string.IsNullOrEmpty(SearchString))
            {
                SearchString = SearchString.Trim().ToLower();
                treatment = treatment.Where(s => s.Name!.ToLower().Contains(SearchString));
            }
            return View(await treatment.ToListAsync());
        }

        // GET: Treatment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatmentModel = await _context.Treatments
                .Include(t => t.TreatmentType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treatmentModel == null)
            {
                return NotFound();
            }

            return View(treatmentModel);
        }

        // GET: Treatment/Create
        public IActionResult Create()
        {
            ViewData["TreatmentTypeId"] = new SelectList(_context.TreatmentTypes, "Id", "Name");
            return View();
        }

        // POST: Treatment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,TreatmentTypeId")] TreatmentModel treatmentModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(treatmentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TreatmentTypeId"] = new SelectList(_context.TreatmentTypes, "Id", "Name", treatmentModel.TreatmentTypeId);
            return View(treatmentModel);
        }

        // GET: Treatment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatmentModel = await _context.Treatments.FindAsync(id);
            if (treatmentModel == null)
            {
                return NotFound();
            }
            ViewData["TreatmentTypeId"] = new SelectList(_context.TreatmentTypes, "Id", "Name", treatmentModel.TreatmentTypeId);
            return View(treatmentModel);
        }

        // POST: Treatment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,TreatmentTypeId")] TreatmentModel treatmentModel)
        {
            if (id != treatmentModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treatmentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreatmentModelExists(treatmentModel.Id))
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
            ViewData["TreatmentTypeId"] = new SelectList(_context.TreatmentTypes, "Id", "Name", treatmentModel.TreatmentTypeId);
            return View(treatmentModel);
        }

        // GET: Treatment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatmentModel = await _context.Treatments
                .Include(t => t.TreatmentType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treatmentModel == null)
            {
                return NotFound();
            }

            return View(treatmentModel);
        }

        // POST: Treatment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var treatmentModel = await _context.Treatments.FindAsync(id);
            if (treatmentModel != null)
            {
                _context.Treatments.Remove(treatmentModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreatmentModelExists(int id)
        {
            return _context.Treatments.Any(e => e.Id == id);
        }
    }
}
