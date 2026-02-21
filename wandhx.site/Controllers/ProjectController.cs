using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WandhxSite.Data;
using WandhxSite.Models;

namespace WandhxSite.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ProjectController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Project
        public async Task<IActionResult> Index()
        {
            return View(await _context.Projects.ToListAsync());
        }

        // GET: Project/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectModel = await _context.Projects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectModel == null)
            {
                return NotFound();
            }

            return View(projectModel);
        }

        // GET: Project/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Technologies,ImageUrl,ImageUrls,CreatedAt,UpdatedAt,DeletedAt")] ProjectModel projectModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectModel);
        }

        // GET: Project/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectModel = await _context.Projects.FindAsync(id);
            if (projectModel == null)
            {
                return NotFound();
            }
            return View(projectModel);
        }

        // POST: Project/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Title,Description,Technologies,ImageUrl,ImageUrls,CreatedAt,UpdatedAt,DeletedAt")] ProjectModel projectModel)
        {
            if (id != projectModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectModelExists(projectModel.Id))
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
            return View(projectModel);
        }

        // GET: Project/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectModel = await _context.Projects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectModel == null)
            {
                return NotFound();
            }

            return View(projectModel);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var projectModel = await _context.Projects.FindAsync(id);
            if (projectModel != null)
            {
                _context.Projects.Remove(projectModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectModelExists(long id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
