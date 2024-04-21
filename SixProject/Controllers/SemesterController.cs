using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixProject.Data;
using SixProject.Models;
using SixProject.Models.ViewModels;

namespace SixProject.Controllers
{
    public class SemesterController : Controller
    {
        private readonly StudentDBContext _context;
        public SemesterController(StudentDBContext context)
        {
            this._context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            var sm = await _context.Semesters.ToListAsync();
            return View(sm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SemesterViewModel svm)
        {
            if (ModelState.IsValid)
            {
                Semester sm = new Semester()
                {
                    SemesterName = svm.SemesterName

                };
                await _context.Semesters.AddAsync(sm);
                await _context.SaveChangesAsync();

            }
            return View();
        }
    }
}
