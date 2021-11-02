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
    public class Project_AuthorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Project_AuthorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Project_Authors
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Project_Authors.Include(p => p.Author).Include(p => p.Project);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Project_Authors/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project_Author = await _context.Project_Authors
                .Include(p => p.Author)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project_Author == null)
            {
                return NotFound();
            }

            return View(project_Author);
        }

        // GET: Project_Authors/Create
        public IActionResult Create()
        {
            // ViewData["AuthorName"] = new SelectList(_context.Authors, "AuthorName", "AuthorName");
            // ViewData["ProjectName"] = new SelectList(_context.Projects, "ProjectName", "ProjectName");
            ViewBag.ListOfProjects = getProjectsSelectList();
            ViewBag.ListOfAuthors = getAuthorsSelectList();
            return View();
        }

        // POST: Project_Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectName,AuthorName")] Project_Author project_Author)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project_Author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorName"] = new SelectList(_context.Authors, "AuthorName", "AuthorName", project_Author.AuthorName);
            ViewData["ProjectName"] = new SelectList(_context.Projects, "ProjectName", "ProjectName", project_Author.ProjectName);
            return View(project_Author);
        }

        // GET: Project_Authors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project_Author = await _context.Project_Authors.FindAsync(id);
            if (project_Author == null)
            {
                return NotFound();
            }
            // ViewData["AuthorName"] = new SelectList(_context.Authors, "AuthorName", "AuthorName", project_Author.AuthorName);
            // ViewData["ProjectName"] = new SelectList(_context.Projects, "ProjectName", "ProjectName", project_Author.ProjectName);
            ViewBag.ListOfProjects = getProjectsSelectList();
            ViewBag.ListOfAuthors = getAuthorsSelectList();
            return View(project_Author);
        }

        // POST: Project_Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectName,AuthorName")] Project_Author project_Author)
        {
            if (id != project_Author.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project_Author);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Project_AuthorExists(project_Author.Id))
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
            ViewData["AuthorName"] = new SelectList(_context.Authors, "AuthorName", "AuthorName", project_Author.AuthorName);
            ViewData["ProjectName"] = new SelectList(_context.Projects, "ProjectName", "ProjectName", project_Author.ProjectName);
            return View(project_Author);
        }

        // GET: Project_Authors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project_Author = await _context.Project_Authors
                .Include(p => p.Author)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project_Author == null)
            {
                return NotFound();
            }

            return View(project_Author);
        }

        // POST: Project_Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project_Author = await _context.Project_Authors.FindAsync(id);
            _context.Project_Authors.Remove(project_Author);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Project_AuthorExists(int id)
        {
            return _context.Project_Authors.Any(e => e.Id == id);
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
