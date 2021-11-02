using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DohunKim.Data;
using DohunKim.Models;
using Microsoft.AspNetCore.Authorization;

namespace DohunKim.Controllers
{
    [Authorize]
    public class ApplicationTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApplicationTypes
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicationType.ToListAsync());
        }

        // GET: ApplicationTypes/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationType = await _context.ApplicationType
                .FirstOrDefaultAsync(m => m.TypeName == id);
            if (applicationType == null)
            {
                return NotFound();
            }

            return View(applicationType);
        }

        // GET: ApplicationTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApplicationTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeName")] ApplicationType applicationType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationType);
        }

        // GET: ApplicationTypes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationType = await _context.ApplicationType.FindAsync(id);
            if (applicationType == null)
            {
                return NotFound();
            }
            return View(applicationType);
        }

        // POST: ApplicationTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TypeName")] ApplicationType applicationType)
        {
            if (id != applicationType.TypeName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationTypeExists(applicationType.TypeName))
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
            return View(applicationType);
        }

        // GET: ApplicationTypes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationType = await _context.ApplicationType
                .FirstOrDefaultAsync(m => m.TypeName == id);
            if (applicationType == null)
            {
                return NotFound();
            }

            return View(applicationType);
        }

        // POST: ApplicationTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var applicationType = await _context.ApplicationType.FindAsync(id);
            _context.ApplicationType.Remove(applicationType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationTypeExists(string id)
        {
            return _context.ApplicationType.Any(e => e.TypeName == id);
        }
    }
}
