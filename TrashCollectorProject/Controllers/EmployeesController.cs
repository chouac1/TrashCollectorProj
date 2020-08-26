using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollectorProject.Data;
using TrashCollectorProject.Models;

namespace TrashCollectorProject.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public IActionResult Index()
        {
            return RedirectToAction("Details");
        }

        // GET: Employees/Details/5
        public IActionResult Details(int? id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employee.Include(c => c.IdentityUser).Where(m => m.IdentityUserId == userId).SingleOrDefault();

            if (employee == null)
            {
                return RedirectToAction("Create");
            }

            return RedirectToAction("TodaysPickup");
        }

        public IActionResult TodaysPickup(int id, Employee employee)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employeePass = _context.Employee.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            var employeeZip = employeePass.ZipCode;
            var customerZip = _context.Customer.Where(z => z.Zipcode == employeeZip).ToList();
            string today = DateTime.Now.DayOfWeek.ToString();
            var todaysPickup = customerZip.Where(d => d.WeeklyPickup == today).ToList();

            //var confirmPickup = _context.Customer.Where(c => c.isConfirmed == false).ToList();
            
            //if ()
            //{

            //}

            return View(todaysPickup);
        }

        public IActionResult MondayPickup(int id, Employee employee)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employeePass = _context.Employee.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            var employeeZip = employeePass.ZipCode;
            var customerZip = _context.Customer.Where(z => z.Zipcode == employeeZip).ToList();

            var mondayPickup = customerZip.Where(d => d.WeeklyPickup == "Monday").ToList();     
            return View(mondayPickup);
        }
        public IActionResult TuesdayPickup(int id, Employee employee)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employeePass = _context.Employee.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            var employeeZip = employeePass.ZipCode;
            var customerZip = _context.Customer.Where(z => z.Zipcode == employeeZip).ToList();
     
            var tuesdayPickup = customerZip.Where(d => d.WeeklyPickup == "Tuesday").ToList();   
            return View(tuesdayPickup);
        }
        public IActionResult WednesdayPickup(int id, Employee employee)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employeePass = _context.Employee.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            var employeeZip = employeePass.ZipCode;
            var customerZip = _context.Customer.Where(z => z.Zipcode == employeeZip).ToList();
              
            var wednesdayPickup = customerZip.Where(d => d.WeeklyPickup == "Wednesday").ToList();
            
            return View(wednesdayPickup);
        }
        public IActionResult ThursdayPickup(int id, Employee employee)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employeePass = _context.Employee.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            var employeeZip = employeePass.ZipCode;
            var customerZip = _context.Customer.Where(z => z.Zipcode == employeeZip).ToList();
             
            var thursdayPickup = customerZip.Where(d => d.WeeklyPickup == "Thursday").ToList();

            return View(thursdayPickup);
        }

        public IActionResult FridayPickup(int id, Employee employee)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employeePass = _context.Employee.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            var employeeZip = employeePass.ZipCode;
            var customerZip = _context.Customer.Where(z => z.Zipcode == employeeZip).ToList();

            var fridayPickup = customerZip.Where(d => d.WeeklyPickup == "Friday").ToList();

            return View(fridayPickup);
        }

        public IActionResult ConfirmedPickup(int id)
        {
            var customer = _context.Customer.Where(c => c.Id == id).SingleOrDefault();
            customer.isConfirmed = true;
            customer.Balance += 10;
            _context.SaveChanges();
            return RedirectToAction("TodaysPickup");
        }


        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName")] Employee employee)
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
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}
