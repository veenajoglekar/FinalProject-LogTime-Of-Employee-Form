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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeLogTimeForm.Controllers
{
    [Authorize(Roles = "Employee")]
    public class LogTimeFormController : Controller
    {
        private readonly EmployeeLogDbContext _context;
        private readonly ILogTimeService _logTimeService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IProjectInfoService _projectInfoService;

        public LogTimeFormController(EmployeeLogDbContext context, ILogTimeService logTimeService,
            UserManager<IdentityUser> userManager, IProjectInfoService projectInfoService)
        {
            _context = context;
            _logTimeService = logTimeService;
            _userManager = userManager;
            _projectInfoService = projectInfoService;
        }

        // GET: LogTimeForm
        public async Task<IActionResult> Index()
        {
            //getting logTime for only logged in user
            var result = await _logTimeService.GetAllDetails();
            IList<LogTimeForm> logTimeList = new List<LogTimeForm>();
            var user = await _userManager.GetUserAsync(User);
            foreach (var data in result)
            {
                if (user != null && data.UserId == user.Id)
                {
                    logTimeList.Add(data);
                }
            }
            return View(logTimeList);
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

        public async Task<string> GetClientByProjectId(int? id)
        {
            return await _projectInfoService.GetClientByProjectId(id);
        }

        // GET: LogTimeForm/Create
        public async Task<IActionResult> Create()
        {
            ViewData["JobId"] = new SelectList(_context.jobInfo, "JobId", "JobName");

            //Getting projects Assigned to logged in user
            var user = await _userManager.GetUserAsync(User);
            var query = from u in _context.AssignUser
                        where u.UserId == user.Id  //comapring UserId which is in AssignUser Model with IdentityUser user
                        select u;

            IList<ProjectInfo> projectList = new List<ProjectInfo>();
            foreach (var project in _context.projectInfo)
            {
                foreach (var data in query)
                {
                    //Getting Projects which are assigned to User
                    if (data.ProjectId == project.ProjectId)
                    {
                        projectList.Add(project);
                    }
                }
            }
            ViewData["ProjectId"] = new SelectList(projectList, "ProjectId", "ProjectName");
            ViewData["BillableStatus"] = new SelectList(_context.projectInfo, "ProjectId", "BillableStatus");

            return View();
        }

        public IActionResult CreateInt()
        {
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
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    logTimeForm.UserId = user.Id;
                }
                bool result = await _logTimeService.CreateDetails(logTimeForm);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["JobId"] = new SelectList(_context.jobInfo, "JobId", "JobName", logTimeForm.JobId);
            ViewData["ProjectId"] = new SelectList(_context.projectInfo, "ProjectId", "ProjectName", logTimeForm.ProjectId);
            return View(logTimeForm);
        }

        // GET: LogTimeForm/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var logTimeForm = await _logTimeService.GetDetailsById(id);
            if (logTimeForm == null)
            {
                return NotFound();
            }
            ViewData["JobId"] = new SelectList(_context.jobInfo, "JobId", "JobName", logTimeForm.JobId);
            ViewData["ProjectId"] = new SelectList(_context.projectInfo, "ProjectId", "ProjectName", logTimeForm.ProjectId);
            return View(logTimeForm);
        }


        // POST: LogTimeForm/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,ProjectId,JobId,WorkItem,Date,Description,Hours,Minutes,Seconds")]
        LogTimeForm logTimeForm)
        {
            if (id != logTimeForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _logTimeService.UpdateDetails(logTimeForm);

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
            ViewData["JobId"] = new SelectList(_context.jobInfo, "JobId", "JobName", logTimeForm.JobId);
            ViewData["ProjectId"] = new SelectList(_context.projectInfo, "ProjectId", "ProjectName", logTimeForm.ProjectId);
            return View(logTimeForm);
        }

        // GET: LogTimeForm/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)

            {
                return NotFound();
            }

            var logTime = await _logTimeService.GetDetailsById(id);
            if (logTime == null)
            {
                return NotFound();
            }

            return View(logTime);
        }

        // POST: LogTimeForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _logTimeService.DeleteDetails(id);

            return RedirectToAction(nameof(Index));
        }

        private bool LogTimeFormExists(int id)
        {
            return _logTimeService.LogTimeFormExists(id);
        }
    }
}