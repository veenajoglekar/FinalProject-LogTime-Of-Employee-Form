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
using Microsoft.AspNetCore.Identity;

namespace EmployeeLogTimeForm.Controllers
{
    [Authorize(Roles = "ProjectManager")]
    public class ProjectInfoController : Controller
    {
        private readonly EmployeeLogDbContext _context;
        private readonly ApplicationDbContext _appContext;
        private readonly IProjectInfoService _projectInfoService;
        private readonly UserManager<IdentityUser> _userManager;

        public ProjectInfoController(EmployeeLogDbContext context, IProjectInfoService projectInfoService ,
            UserManager<IdentityUser> userManager, ApplicationDbContext appContext)
        {
            _context = context;
            _appContext = appContext;
            _projectInfoService = projectInfoService;
            _userManager = userManager;
        }

        // GET: ProjectInfo
        public async Task<IActionResult> Index(string searchBy, string search, int pageNumber = 1)
        {
            var result = await _projectInfoService.GetAllProjectInfo();
            if (search == null)
            {
                return View(await PaginatedList<ProjectInfo>.CreateAsync(result, pageNumber, 3));
            }
            var data = result.Where(e => e.ClientName.ToLower().Contains(search.ToLower()) || e.ProjectName.ToLower().Contains(search.ToLower()))
                    .ToList();
            return View(await PaginatedList<ProjectInfo>.CreateAsync
                            (data, pageNumber, 3));
            //if (searchBy == "ClientName")
            //{
            //    return View(result.Where (e => e.ClientName.ToLower().Contains(search.ToLower()))
            //        .ToList());
            //}
            //else
            //{
            //    return View(result.Where(e => e.ProjectName.ToLower().Contains(search.ToLower()))
            //        .ToList());

            //}

            //var result = await _projectInfoService.GetAllProjectInfo();
            //return View(result);
        }

        // GET: ProjectInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projInfo = await _projectInfoService.GetProjInfoById(id);

            if (projInfo == null)

            {
                return NotFound();
            }

            return View(projInfo);
        }

        // GET: ProjectInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjectInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,ProjectName,ClientName,DueDate,BillableStatus,Costing")]
        ProjectInfo projectInfo)
        {
            if (ModelState.IsValid)
            {
                bool result = await _projectInfoService.CreateProject(projectInfo);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(projectInfo);
        }

        // GET: ProjectInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectInfo = await _projectInfoService.GetProjInfoById(id);
            if (projectInfo == null)
            {
                return NotFound();
            }
            return View(projectInfo);
        }

        // POST: ProjectInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,ProjectName,ClientName,DueDate,BillableStatus,Costing")]
        ProjectInfo projectInfo)
        {
            if (id != projectInfo.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _projectInfoService.UpdateProject(projectInfo);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectInfoExists(projectInfo.ProjectId))
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
            return View(projectInfo);
        }

        // GET: ProjectInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)

            {
                return NotFound();
            }

            var projectInfo = await _projectInfoService.GetProjInfoById(id);
            if (projectInfo == null)
            {
                return NotFound();
            }

            return View(projectInfo);
        }

        // POST: ProjectInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _projectInfoService.GetProjInfoById(id);

            return RedirectToAction(nameof(Index));
        }

        private bool ProjectInfoExists(int id)
        {
            return _projectInfoService.ProjectInfoExists(id);
        }

        public async Task<IActionResult> Assign()
        {
            var user = await _userManager.GetUsersInRoleAsync("Employee");   
            ViewData["UserId"]= new SelectList(user, "Id", "Email");
            ViewData["ProjectId"]= new SelectList(_context.projectInfo, "ProjectId", "ProjectName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Assign([Bind("ProjectId,UserId")]
        AssignUser assignUser)
        {
            if (ModelState.IsValid)
            {
                bool result = await _projectInfoService.AssignProject(assignUser);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(assignUser);
        }
    }
}
