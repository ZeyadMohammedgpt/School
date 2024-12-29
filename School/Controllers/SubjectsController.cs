using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School.Models;
using School.Models.Entity;

namespace School.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly AppDbContext _context;

        public SubjectsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Subjects.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {

            var subjects = await _context.Subjects
                .FirstOrDefaultAsync(m => m.Id == id);
            return View(subjects);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Subjects subjects)
        {
            _context.Add(subjects);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {

            var subjects = await _context.Subjects.FindAsync(id);
            return View(subjects);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Subjects subjects)
        {
            _context.Update(subjects);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var subjects = await _context.Subjects
                .FirstOrDefaultAsync(m => m.Id == id);
            return View(subjects);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Subjects subjects)
        {
            _context.Subjects.Remove(subjects);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
