using EmployeeLogTimeForm.DAL.Data;
using EmployeeLogTimeForm.DAL.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLogTimeForm.Services.Services
{
    public interface IJobInfoService
    {
        public Task<List<JobInfo>> GetAllJobInfo();
        public Task<JobInfo> GetJobInfoById(int? id);

        public Task<bool> CreateJob(JobInfo jobInfo);
        public Task UpdateJob(JobInfo jobInfo);
        public Task DeleteJob(int id);
        public bool JobInfoExists(int id);

    }
    public class JobInfoService : IJobInfoService
    {
        public async Task<List<JobInfo>> GetAllJobInfo()
        {
            using (var Context = new EmployeeLogDbContext())
            {

                return await Context.jobInfo.ToListAsync();

            }
        }

        public async Task<JobInfo> GetJobInfoById(int? id)
        {
            using (var Context = new EmployeeLogDbContext())
            {
                return await Context.jobInfo.FirstOrDefaultAsync(m => m.JobId == id);
            }
        }


        public async Task<bool> CreateJob(JobInfo jobInfo)
        {
            using (var Context = new EmployeeLogDbContext())
            {
                try
                {
                    Context.Add(jobInfo);
                    await Context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task UpdateJob(JobInfo jobInfo)
        {
            using (var Context = new EmployeeLogDbContext())
            {

                Context.Update(jobInfo);
                await Context.SaveChangesAsync();

            }
        }

        public async Task DeleteJob(int id)
        {
            using (var Context = new EmployeeLogDbContext())
            {
                var jobInfo = await Context.jobInfo.FindAsync(id);

                Context.jobInfo.Remove(jobInfo);
                await Context.SaveChangesAsync();
            }
        }

        public bool JobInfoExists(int id)
        {
            using (var Context = new EmployeeLogDbContext())
            {
                return Context.jobInfo.Any(e => e.JobId == id);
            }
        }
    }
}
