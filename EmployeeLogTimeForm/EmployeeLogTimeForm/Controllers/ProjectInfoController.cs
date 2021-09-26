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
    public class ProjectInfoController : Controller
    {
        private readonly EmployeeLogDbContext _context;
        private readonly IProjectInfoService _projectInfoService;

        public ProjectInfoController(EmployeeLogDbContext context, IProjectInfoService projectInfoService)
        {
            _context = context;
            _projectInfoService = projectInfoService;
        }

        // GET: ProjectInfo
        public async Task<IActionResult> Index(string searchBy, string search)
        {
            var result = await _projectInfoService.GetAllProjectInfo();
            if (search == null)
            {
                return View(result);
            }
            return View(result.Where(e => e.ClientName.ToLower().Contains(search.ToLower()) || e.ProjectName.ToLower().Contains(search.ToLower()))
                    .ToList());
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
    }
}
