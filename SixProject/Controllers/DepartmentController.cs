using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SixProject.Data;
using SixProject.Models;
using SixProject.Models.ViewModels;
using System.Runtime.Intrinsics.Arm;

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
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var dpt= await _context.Departments.FindAsync(id);
            
            if (id == null)
            {
                return RedirectToAction("Index");

            }

            DepartmentViewModel dvm = new DepartmentViewModel()
            {
                DepartmentID = dpt.DepartmentID,
                DepartmentName = dpt.DepartmentName
            };
            
            return View(dvm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, DepartmentViewModel dvm)
        {
            var d = await _context.Departments.FindAsync(id);

            if (id == null)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                d.DepartmentName=dvm.DepartmentName;
                
                await _context.SaveChangesAsync();
                ViewBag.msg = "Data updated successfully!!!";

                //return RedirectToAction("Index");
            }

            
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var d = await _context.Departments.FindAsync(id);
            if(id == null)
            {
                return RedirectToAction("Index");
            }

            _context.Departments.Remove(d);
            await _context.SaveChangesAsync(true);
            return RedirectToAction("Index");
        }

    }
}
