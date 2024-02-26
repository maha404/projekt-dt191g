using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using admininterface.Data;
using admininterface.Models;

namespace admininterface.Controllers
{
    public class TreatmentTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TreatmentTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TreatmentType
        public async Task<IActionResult> Index()
        {
            return View(await _context.TreatmentTypes.ToListAsync());
        }

        // GET: TreatmentType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatmentTypeModel = await _context.TreatmentTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treatmentTypeModel == null)
            {
                return NotFound();
            }

            return View(treatmentTypeModel);
        }

        // GET: TreatmentType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TreatmentType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] TreatmentTypeModel treatmentTypeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(treatmentTypeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(treatmentTypeModel);
        }

        // GET: TreatmentType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatmentTypeModel = await _context.TreatmentTypes.FindAsync(id);
            if (treatmentTypeModel == null)
            {
                return NotFound();
            }
            return View(treatmentTypeModel);
        }

        // POST: TreatmentType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] TreatmentTypeModel treatmentTypeModel)
        {
            if (id != treatmentTypeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treatmentTypeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreatmentTypeModelExists(treatmentTypeModel.Id))
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
            return View(treatmentTypeModel);
        }

        // GET: TreatmentType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatmentTypeModel = await _context.TreatmentTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treatmentTypeModel == null)
            {
                return NotFound();
            }

            return View(treatmentTypeModel);
        }

        // POST: TreatmentType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var treatmentTypeModel = await _context.TreatmentTypes.FindAsync(id);
            if (treatmentTypeModel != null)
            {
                _context.TreatmentTypes.Remove(treatmentTypeModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreatmentTypeModelExists(int id)
        {
            return _context.TreatmentTypes.Any(e => e.Id == id);
        }
    }
}
