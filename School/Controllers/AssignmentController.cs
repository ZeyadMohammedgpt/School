using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School.Models;
using School.Models.Entity;
using School.ViewModel;

namespace School.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly AppDbContext _context;

        public AssignmentController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Assignments.ToListAsync());
        }

        public async Task<IActionResult> Details(int  id)
        {

            var assignmentViewModel = await _context.AssignmentViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            return View(assignmentViewModel);
        }

        public async Task<IActionResult> Create()
        {
            var T = await _context.Teachers.ToListAsync();
            var S = await _context.Subjects.ToListAsync();

            AssignmentViewModel viewModel = new()
            {
                Teachers = T,
                Subjects = S
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AssignmentViewModel viewModel)
        {
            Assignment ass = new()
            {
                TeacherId = viewModel.TeacherId,
                SubjectsId = viewModel.SubjectsId,
                AssignedDate = viewModel.AssignedDate,
            };
            await _context.AddAsync(ass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var assignmentViewModel = await _context.AssignmentViewModel.FindAsync(id);
            return View(assignmentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AssignmentViewModel viewModel)
        {

           var opp = await _context.AssignmentViewModel.FindAsync(viewModel.Id);
            _context.Update(opp);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var assignment = await _context.Assignments
                .FirstOrDefaultAsync(m => m.Id == id);
           return View(assignment);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(Assignment assignment)
        {

            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
