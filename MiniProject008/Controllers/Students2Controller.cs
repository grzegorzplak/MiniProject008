using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProject008.Models;

namespace MiniProject008.Controllers
{
    public class Students2Controller : Controller
    {
        private readonly Context _context;

        public Students2Controller(Context context)
        {
            _context = context;
        }

        public IActionResult ShowStudents()
        {
            var result = _context.Students.Include(s => s.LanguageLevel);
            return View(result);
        }

        [HttpGet]
        public IActionResult CreateStudent()
        {
            ViewData["LanguageLeves"] = _context.LanguageLevels.OrderBy(o => o.Id).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult CreateStudent([Bind("Id,Name,LanguageLevelId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("ShowStudents");
            }
            ViewData["LanguageLeves"] = _context.LanguageLevels.OrderBy(o => o.Id).ToList();
            return View(student);
        }
    }
}
