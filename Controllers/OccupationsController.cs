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
    public class OccupationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OccupationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Occupations
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Occupations.Include(o => o.Author);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Occupations/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var occupation = await _context.Occupations
                .Include(o => o.Author)
                .FirstOrDefaultAsync(m => m.OccupationTitle == id);
            if (occupation == null)
            {
                return NotFound();
            }

            return View(occupation);
        }

        // GET: Occupations/Create
        public IActionResult Create()
        {
            // ViewData["AuthorName"] = new SelectList(_context.Authors, "AuthorName", "AuthorName");
            ViewBag.ListOfAuthors = getAuthorsSelectList();
            return View();
        }

        // POST: Occupations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OccupationTitle,AuthorName")] Occupation occupation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(occupation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorName"] = new SelectList(_context.Authors, "AuthorName", "AuthorName", occupation.AuthorName);
            return View(occupation);
        }

        // GET: Occupations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var occupation = await _context.Occupations.FindAsync(id);
            if (occupation == null)
            {
                return NotFound();
            }
            // ViewData["AuthorName"] = new SelectList(_context.Authors, "AuthorName", "AuthorName", occupation.AuthorName);
            ViewBag.ListOfAuthors = getAuthorsSelectList();
            return View(occupation);
        }

        // POST: Occupations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("OccupationTitle,AuthorName")] Occupation occupation)
        {
            if (id != occupation.OccupationTitle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(occupation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OccupationExists(occupation.OccupationTitle))
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
            ViewData["AuthorName"] = new SelectList(_context.Authors, "AuthorName", "AuthorName", occupation.AuthorName);
            return View(occupation);
        }

        // GET: Occupations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var occupation = await _context.Occupations
                .Include(o => o.Author)
                .FirstOrDefaultAsync(m => m.OccupationTitle == id);
            if (occupation == null)
            {
                return NotFound();
            }

            return View(occupation);
        }

        // POST: Occupations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var occupation = await _context.Occupations.FindAsync(id);
            _context.Occupations.Remove(occupation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OccupationExists(string id)
        {
            return _context.Occupations.Any(e => e.OccupationTitle == id);
        }

        private List<SelectListItem> getAuthorsSelectList()
        {
            List<Author> authorList = _context.Authors.ToList();
            List<SelectListItem> list = authorList.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.AuthorName,
                    Value = a.AuthorName,
                    Selected = false
                };
            });
            return list;
        }
    }
}
