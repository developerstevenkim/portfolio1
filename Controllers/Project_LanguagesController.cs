using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Do4.Models;
using DohunKim.Data;
using DohunKim.Models;
using Microsoft.AspNetCore.Authorization;

namespace DohunKim.Controllers
{
    [Authorize]
    public class Project_LanguagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Project_LanguagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Project_Languages
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Project_Languages.Include(p => p.Language).Include(p => p.Project);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Project_Languages/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project_Language = await _context.Project_Languages
                .Include(p => p.Language)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project_Language == null)
            {
                return NotFound();
            }

            return View(project_Language);
        }

        // GET: Project_Languages/Create
        public IActionResult Create()
        {
            // ViewData["LanguageName"] = new SelectList(_context.Languages, "LanguageName", "LanguageName");
            // ViewData["ProjectName"] = new SelectList(_context.Projects, "ProjectName", "ProjectName");
            ViewBag.ListOfProjects = getProjectsSelectList();
            ViewBag.ListOfLanguages = getLanguagesSelectList();
            return View();
        }

        // POST: Project_Languages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectName,LanguageName")] Project_Language project_Language)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project_Language);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LanguageName"] = new SelectList(_context.Languages, "LanguageName", "LanguageName", project_Language.LanguageName);
            ViewData["ProjectName"] = new SelectList(_context.Projects, "ProjectName", "ProjectName", project_Language.ProjectName);
            return View(project_Language);
        }

        // GET: Project_Languages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project_Language = await _context.Project_Languages.FindAsync(id);
            if (project_Language == null)
            {
                return NotFound();
            }
            // ViewData["LanguageName"] = new SelectList(_context.Languages, "LanguageName", "LanguageName", project_Language.LanguageName);
            // ViewData["ProjectName"] = new SelectList(_context.Projects, "ProjectName", "ProjectName", project_Language.ProjectName);
            ViewBag.ListOfProjects = getProjectsSelectList();
            ViewBag.ListOfLanguages = getLanguagesSelectList();
            return View(project_Language);
        }

        // POST: Project_Languages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectName,LanguageName")] Project_Language project_Language)
        {
            if (id != project_Language.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project_Language);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Project_LanguageExists(project_Language.Id))
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
            ViewData["LanguageName"] = new SelectList(_context.Languages, "LanguageName", "LanguageName", project_Language.LanguageName);
            ViewData["ProjectName"] = new SelectList(_context.Projects, "ProjectName", "ProjectName", project_Language.ProjectName);
            return View(project_Language);
        }

        // GET: Project_Languages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project_Language = await _context.Project_Languages
                .Include(p => p.Language)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project_Language == null)
            {
                return NotFound();
            }

            return View(project_Language);
        }

        // POST: Project_Languages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project_Language = await _context.Project_Languages.FindAsync(id);
            _context.Project_Languages.Remove(project_Language);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Project_LanguageExists(int id)
        {
            return _context.Project_Languages.Any(e => e.Id == id);
        }

        private List<SelectListItem> getProjectsSelectList()
        {
            List<Project> projectList = _context.Projects.ToList();
            List<SelectListItem> list = projectList.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.ProjectName,
                    Value = a.ProjectName,
                    Selected = false
                };
            });
            return list;
        }

        private List<SelectListItem> getLanguagesSelectList()
        {
            List<Language> languageList = _context.Languages.ToList();
            List<SelectListItem> list = languageList.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.LanguageName,
                    Value = a.LanguageName,
                    Selected = false
                };
            });
            return list;
        }
    }
}
