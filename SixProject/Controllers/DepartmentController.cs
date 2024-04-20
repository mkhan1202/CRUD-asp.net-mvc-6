using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SixProject.Data;
using SixProject.Models;
using SixProject.Models.ViewModels;

namespace SixProject.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly StudentDBContext _context;

        public DepartmentController(StudentDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dpt= await _context.Departments.ToListAsync();
            return View(dpt);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentViewModel dvm)
        {
            if(ModelState.IsValid)
            {
                Department dpt = new Department()
                {
                    DepartmentName = dvm.DepartmentName
                };
                await _context.Departments.AddAsync(dpt);
                await _context.SaveChangesAsync();
                ViewBag.msg = "Data saved successfully";
                return RedirectToAction("");
            }
            return View();
        }
    }
}
