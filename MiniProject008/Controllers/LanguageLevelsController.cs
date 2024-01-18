using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniProject008.Models;

namespace MiniProject008.Controllers
{
    public class LanguageLevelsController : Controller
    {
        private readonly Context _context;

        public LanguageLevelsController(Context context)
        {
            _context = context;
        }

        // GET: LanguageLevels
        public async Task<IActionResult> Index()
        {
            return View(await _context.LanguageLevels.ToListAsync());
        }

        // GET: LanguageLevels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var languageLevel = await _context.LanguageLevels
                .Include(l => l.Students)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (languageLevel == null)
            {
                return NotFound();
            }

            return View(languageLevel);
        }

        // GET: LanguageLevels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LanguageLevels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Level")] LanguageLevel languageLevel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(languageLevel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(languageLevel);
        }

        // GET: LanguageLevels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var languageLevel = await _context.LanguageLevels.FindAsync(id);
            if (languageLevel == null)
            {
                return NotFound();
            }
            return View(languageLevel);
        }

        // POST: LanguageLevels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Level")] LanguageLevel languageLevel)
        {
            if (id != languageLevel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(languageLevel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LanguageLevelExists(languageLevel.Id))
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
            return View(languageLevel);
        }

        // GET: LanguageLevels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var languageLevel = await _context.LanguageLevels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (languageLevel == null)
            {
                return NotFound();
            }

            return View(languageLevel);
        }

        // POST: LanguageLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var languageLevel = await _context.LanguageLevels.FindAsync(id);
            if (languageLevel != null)
            {
                _context.LanguageLevels.Remove(languageLevel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LanguageLevelExists(int id)
        {
            return _context.LanguageLevels.Any(e => e.Id == id);
        }
    }
}
