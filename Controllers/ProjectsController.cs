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
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Projects
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Projects
                .Include(p => p.ApplicationType)
                .Include(p => p.Project_Languages)
                .Include(p => p.Project_Authors)
                .OrderBy(p => p.ReleaseDate);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Projects/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.ApplicationType)
                .FirstOrDefaultAsync(m => m.ProjectName == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            // ViewData["TypeName"] = new SelectList(_context.ApplicationType, "TypeName", "TypeName");
            ViewBag.ListOfTypes = getTypesSelectList();
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectName,TypeName,ProjectDesc,ReleaseDate,GithubURL,DemoURL")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeName"] = new SelectList(_context.ApplicationType, "TypeName", "TypeName", project.TypeName);
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            ViewBag.ListOfTypes = getTypesSelectList();
            // ViewData["TypeName"] = new SelectList(_context.ApplicationType, "TypeName", "TypeName", project.TypeName);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProjectName,TypeName,ProjectDesc,ReleaseDate,GithubURL,DemoURL")] Project project)
        {
            if (id != project.ProjectName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectName))
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
            ViewData["TypeName"] = new SelectList(_context.ApplicationType, "TypeName", "TypeName", project.TypeName);
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.ApplicationType)
                .FirstOrDefaultAsync(m => m.ProjectName == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var project = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(string id)
        {
            return _context.Projects.Any(e => e.ProjectName == id);
        }

        private List<SelectListItem> getTypesSelectList()
        {
            List<ApplicationType> typeList = _context.ApplicationType.ToList();
            List<SelectListItem> list = typeList.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.TypeName,
                    Value = a.TypeName,
                    Selected = false
                };
            });
            return list;
        }
    }
}
