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
using Microsoft.AspNetCore.Authorization;

namespace EmployeeLogTimeForm.Controllers
{
    [Authorize(Roles = "ProjectManager")]
    public class JobInfoController : Controller
    {
        private readonly EmployeeLogDbContext _context;
        private readonly IJobInfoService _jobInfoService;

        public JobInfoController(EmployeeLogDbContext context, IJobInfoService jobInfoService)
        {
            _context = context;
            _jobInfoService = jobInfoService;
        }

        // GET: JobInfo
        public async Task<IActionResult> Index()
        {
            var result = await _jobInfoService.GetAllJobInfo();
            return View(result);
        }

        // GET: JobInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                if (id == null)
                {
                    return NotFound();
                }

            var jobInfo = await _jobInfoService.GetJobInfoById(id);

            if (jobInfo == null)

            {
                return NotFound();
            }

            return View(jobInfo);
        }

        // GET: JobInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobId,JobName")] JobInfo jobInfo)
        {
            if (ModelState.IsValid)
            {
                bool result = await _jobInfoService.CreateJob(jobInfo);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(jobInfo);
        }

        // GET: JobInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobInfo = await _jobInfoService.GetJobInfoById(id);
            if (jobInfo == null)
            {
                return NotFound();
            }
            return View(jobInfo);
        }

        // POST: JobInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobId,JobName")] JobInfo jobInfo)
        {
            if (id != jobInfo.JobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _jobInfoService.UpdateJob(jobInfo);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobInfoExists(jobInfo.JobId))
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
            return View(jobInfo);
        }

        // GET: JobInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)

            {
                return NotFound();
            }

            var jobInfo = await _jobInfoService.GetJobInfoById(id);
            if (jobInfo == null)
            {
                return NotFound();
            }

            return View(jobInfo);
        }

        // POST: JobInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _jobInfoService.DeleteJob(id);

            return RedirectToAction(nameof(Index));
        }

        private bool JobInfoExists(int id)
        {
            return _jobInfoService.JobInfoExists(id);
        }
    }
}
