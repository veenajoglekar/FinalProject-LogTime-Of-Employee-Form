using EmployeeLogTimeForm.DAL.Data;
using EmployeeLogTimeForm.DAL.Data.Model;
using EmployeeLogTimeForm.Services.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLogTimeForm.Services.Services
{
    public interface IProjectInfoService
    {
        public Task<List<ProjectInfo>> GetAllProjectInfo();
        public Task<ProjectInfo> GetProjInfoById(int? id);
        public Task<string> GetClientByProjectId(int? id);
        public Task<bool> CreateProject(ProjectInfo projectInfo);
        public Task UpdateProject(ProjectInfo projectInfo);
        public Task DeleteProject(int id);
        public bool ProjectInfoExists(int id);
        public Task<bool> AssignProject(AssignUser assignUser);

        //public Task<List<vwJoinData>> JoinTables(ApplicationDbContext AppContext);

    }
    public class ProjectInfoService : IProjectInfoService
    {

        public async Task<List<ProjectInfo>> GetAllProjectInfo()
        {
            using (var Context = new EmployeeLogDbContext())
            {
                return await Context.projectInfo.ToListAsync();
            }
        }

        public async Task<ProjectInfo> GetProjInfoById(int? id)
        {
            using (var Context = new EmployeeLogDbContext())
            {
                return await Context.projectInfo.FirstOrDefaultAsync(m => m.ProjectId == id);
            }
        }

        public async Task<string> GetClientByProjectId(int? id)
        {
            if (id == null)
            {
                return "null";
            }

            using (var Context = new EmployeeLogDbContext())
            {
                var client = await Context.projectInfo.FirstOrDefaultAsync(c => c.ProjectId == id);
                return client.ClientName;
            }
            
        }

        public async Task<bool> CreateProject(ProjectInfo projectInfo)
        {
            using (var Context = new EmployeeLogDbContext())
            {
                try
                {
                    Context.Add(projectInfo);
                    await Context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task UpdateProject(ProjectInfo projectInfo)
        {
            using (var Context = new EmployeeLogDbContext())
            {

                Context.Update(projectInfo);
                await Context.SaveChangesAsync();

            }
        }

        public async Task DeleteProject(int id)
        {
            using (var Context = new EmployeeLogDbContext())
            {
                var projectInfo = await Context.projectInfo.FindAsync(id);

                Context.projectInfo.Remove(projectInfo);
                await Context.SaveChangesAsync();
            }
        }

        public bool ProjectInfoExists(int id)
        {
            using (var Context = new EmployeeLogDbContext())
            {
                return Context.projectInfo.Any(e => e.ProjectId == id);
            }
        }

        public async Task<bool> AssignProject(AssignUser assignUser)
        {
            using (var Context = new EmployeeLogDbContext())
            {
                try
                {
                    Context.Add(assignUser);
                    await Context.SaveChangesAsync();
                }
                catch (Exception )
                {
                    return false;
                }
                return true;
            }
        }

      

        //public async Task<List<vwJoinData>> JoinTables(ApplicationDbContext AppContext)
        //{

        //    using (var Context = new EmployeeLogDbContext())
        //    {
        //        var users = AppContext.Users;
        //        var data = from p in Context.projectInfo
        //                         join a in Context.AssignUser on p.ProjectId equals a.ProjectId
        //                         join u in users on a.UserId equals u.Id
        //                         select new vwJoinData
        //                         {
        //                             ProjectName = p.ProjectName,
        //                             Email = u.Email
        //                         };
        //        return await data.ToListAsync();

        //    }

        //}

    }
}
