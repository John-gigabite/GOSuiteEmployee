using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GOSuiteEmployee.Data;
using GOSuiteEmployee.Models;

namespace GOSuiteEmployee.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index(string searchString, string sortOrder)
        {
            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "NameSort" : "";
            ViewData["EmployeeIDParam"] = sortOrder == "EmployeeId" ? "" : "id_sort";
            ViewData["TitleSortParam"] = sortOrder == "Title" ? "" : "title_sort";
            ViewData["SalarySortParam"] = sortOrder == "Salary" ? "" : "salary_sort";
            ViewData["TenureSortParam"] = sortOrder == "Tenure" ? "" : "tenure_sort";

            ViewData["CurrentFilter"] = searchString;

            var employee = from e in _context.Employee
                           select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                employee = employee.Where(e => e.EmployeeName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "NameSort":
                    employee = employee.OrderBy(e => e.EmployeeName);
                    break;
                case "id_sort":
                    employee = employee.OrderBy(e => e.EmployeeId);
                    break;
                case "title_sort":
                    employee = employee.OrderBy(e => e.Title);
                    break;
                case "salary_sort":
                    employee = employee.OrderByDescending(e => e.Salary);
                    break;
                case "tenure_sort":
                    employee = employee.OrderByDescending(e => e.Tenure);
                    break;
                default:
                    employee = employee.OrderBy(e => e.EmployeeId);
                    break;
            }


            return View(await employee.AsNoTracking().ToListAsync());


            /*return _context.Employee != null ? 
                        View(await _context.Employee.ToListAsync()) :
                        Problem("Entity set 'employeeManagmentSoftwareContext.Employee'  is null.");*/
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeName,EmployeeId,Title,Salary,Tenure")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                TempData["success"] = "Employee added successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeName,EmployeeId,Title,Salary,Tenure")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["success"] = "Employee updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee != null)
            {
                _context.Employee.Remove(employee);
            }

            await _context.SaveChangesAsync();
            TempData["success"] = "Employee removed successfully";
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}
