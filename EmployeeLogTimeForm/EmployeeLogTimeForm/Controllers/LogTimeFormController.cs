using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeLogTimeForm.DAL.Data;
using EmployeeLogTimeForm.DAL.Data.Model;
using EmployeeLogTimeForm.Services.Services;

namespace EmployeeLogTimeForm.Controllers
{
    public class LogTimeFormController : Controller
    {
        private readonly EmployeeLogDbContext _context;
        private readonly ILogTimeService _logTimeService;

        public LogTimeFormController(EmployeeLogDbContext context, ILogTimeService logTimeService)
        {
            _context = context;
            _logTimeService = logTimeService;
        }

        // GET: LogTimeForm
        public async Task<IActionResult> Index()
        {
            var result = await _logTimeService.GetAllDetails();
            return View(result);
        }

        // GET: LogTimeForm/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var LogDetails = await _logTimeService.GetDetailsById(id);

            if (LogDetails == null)

            {
                return NotFound();
            }

            return View(LogDetails);
        }

        // GET: LogTimeForm/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.clients, "ClientId", "ClientId");
            ViewData["JobId"] = new SelectList(_context.jobInfo, "JobId", "JobId");
            ViewData["ProjectId"] = new SelectList(_context.projectInfo, "ProjectId", "ProjectId");
            return View();
        }

        // POST: LogTimeForm/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientId,ProjectId,JobId,WorkItem,Date,Description,Hours,Minutes,Seconds")] LogTimeForm logTimeForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logTimeForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.clients, "ClientId", "ClientId", logTimeForm.ClientId);
            ViewData["JobId"] = new SelectList(_context.jobInfo, "JobId", "JobId", logTimeForm.JobId);
            ViewData["ProjectId"] = new SelectList(_context.projectInfo, "ProjectId", "ProjectId", logTimeForm.ProjectId);
            return View(logTimeForm);
        }

        // GET: LogTimeForm/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logTimeForm = await _context.logTimeForm.FindAsync(id);
            if (logTimeForm == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.clients, "ClientId", "ClientId", logTimeForm.ClientId);
            ViewData["JobId"] = new SelectList(_context.jobInfo, "JobId", "JobId", logTimeForm.JobId);
            ViewData["ProjectId"] = new SelectList(_context.projectInfo, "ProjectId", "ProjectId", logTimeForm.ProjectId);
            return View(logTimeForm);
        }

        // POST: LogTimeForm/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,ProjectId,JobId,WorkItem,Date,Description,Hours,Minutes,Seconds")] LogTimeForm logTimeForm)
        {
            if (id != logTimeForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logTimeForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogTimeFormExists(logTimeForm.Id))
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
            ViewData["ClientId"] = new SelectList(_context.clients, "ClientId", "ClientId", logTimeForm.ClientId);
            ViewData["JobId"] = new SelectList(_context.jobInfo, "JobId", "JobId", logTimeForm.JobId);
            ViewData["ProjectId"] = new SelectList(_context.projectInfo, "ProjectId", "ProjectId", logTimeForm.ProjectId);
            return View(logTimeForm);
        }

        // GET: LogTimeForm/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logTimeForm = await _context.logTimeForm
                .Include(l => l.Client)
                .Include(l => l.JobInfo)
                .Include(l => l.ProjectInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logTimeForm == null)
            {
                return NotFound();
            }

            return View(logTimeForm);
        }

        // POST: LogTimeForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var logTimeForm = await _context.logTimeForm.FindAsync(id);
            _context.logTimeForm.Remove(logTimeForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogTimeFormExists(int id)
        {
            return _context.logTimeForm.Any(e => e.Id == id);
        }
    }
}
