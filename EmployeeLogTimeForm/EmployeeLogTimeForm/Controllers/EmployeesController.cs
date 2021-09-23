using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeLogTimeForm.DAL.Data.Model;
using EmployeeLogTimeForm.Services.Services;
using EmployeeLogTimeForm.DAL.Data;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeLogTimeForm.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeesController : Controller
    {
        private readonly EmployeeLogDbContext _context;
        private readonly IEmpService _empService;
        public EmployeesController(EmployeeLogDbContext context, IEmpService empService)
        {
            _context = context;
            _empService = empService;
        }

        // GET: EmployeeAdvns
        public async Task<IActionResult> Index()
        {
            var result = await _empService.GetAllEmployee();
            return View(result);
        }



        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var EmpDetail = await _empService.GetEmpDetailsById(id);

            if (EmpDetail == null)

            {
                return NotFound();
            }

            return View(EmpDetail);
        }

        //GET: EmpFamilyDetAdvns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpFamilyDetAdvns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId, FirstName, LastName")] Employee emp)
        {
            if (ModelState.IsValid)
            {
                bool result = await _empService.CreateEmployee(emp);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(emp);
        }

        // GET: EmpFamilyDetAdvns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emp = await _empService.GetEmpDetailsById(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        // POST: EmpFamilyDetAdvns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,FirstName,LastName")] Employee emp)
        {
            if (id != emp.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _empService.UpdateEmployee(emp);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpDetAdvnExists(emp.EmployeeId))
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
            return View(emp);
        }

        // GET: EmpFamilyDetAdvns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)

            {
                return NotFound();
            }

            var empFamilyDetAdvn = await _empService.GetEmpDetailsById(id);
            if (empFamilyDetAdvn == null)
            {
                return NotFound();
            }

            return View(empFamilyDetAdvn);
        }

        // POST: EmpFamilyDetAdvns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _empService.DeleteEmployee(id);

            return RedirectToAction(nameof(Index));
        }

        private bool EmpDetAdvnExists(int id)
        {
            return _empService.EmployeeExists(id);
        }
    }
}
