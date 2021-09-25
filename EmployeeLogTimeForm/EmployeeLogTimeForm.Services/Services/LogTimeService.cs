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
    public interface ILogTimeService
    {
        public Task<List<LogTimeForm>> GetAllDetails();
        public Task<LogTimeForm> GetDetailsById(int? id);

        public Task<bool> CreateDetails(LogTimeForm logTimeForm);
        public Task UpdateDetails(LogTimeForm logTimeForm);
        public Task DeleteDetails(int id);
        public bool LogTimeFormExists(int id);
    }
    public class LogTimeService : ILogTimeService
    {
        public async Task<List<LogTimeForm>> GetAllDetails()
        {
            using (var Context = new EmployeeLogDbContext())
            {

                return await Context.logTimeForm.Include(l => l.JobInfo).Include(l => l.ProjectInfo).ToListAsync(); 
            }
        }

        public async Task<LogTimeForm> GetDetailsById(int? id)
        {
            using (var Context = new EmployeeLogDbContext())
            {
                return await Context.logTimeForm
                .Include(l => l.JobInfo)
                .Include(l => l.ProjectInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            }
        }

        public async Task<bool> CreateDetails(LogTimeForm logTimeForm)
        {
            using (var Context = new EmployeeLogDbContext())
            {
                try
                {
                    Context.Add(logTimeForm);
                    await Context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
                return true;
            }
        }

        public async Task UpdateDetails(LogTimeForm logTimeForm)
        {
            using (var Context = new EmployeeLogDbContext())
            {

                Context.Update(logTimeForm);
                await Context.SaveChangesAsync();

            }
        }

        public async Task DeleteDetails(int id)
        {
            using (var Context = new EmployeeLogDbContext())
            {
                var logTime = await Context.logTimeForm
                .Include(l => l.JobInfo)
                .Include(l => l.ProjectInfo)
                .FirstOrDefaultAsync(m => m.Id == id);

                Context.logTimeForm.Remove(logTime);
                await Context.SaveChangesAsync();
            }
        }

        public bool LogTimeFormExists(int id)
        {
            using (var Context = new EmployeeLogDbContext())
            {
                return Context.logTimeForm.Any(e => e.Id == id);
            }
        }
    }
}
