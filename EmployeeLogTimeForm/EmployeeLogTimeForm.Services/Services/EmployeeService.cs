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
    public interface IEmpService
    {
        public Task<List<Employee>> GetAllEmployee();
        public Task<Employee> GetEmpDetailsById(int? id);

        public Task<bool> CreateEmployee(Employee emp);
        public Task UpdateEmployee(Employee emp);
        public Task DeleteEmployee(int id);
        public bool EmployeeExists(int id);
    }
    public class EmployeeService : IEmpService
    {

        public async Task<List<Employee>> GetAllEmployee()
        {
            using (var Context = new EmployeeLogDbContext())
            {

                return await Context.employees.ToListAsync();
            }
        }

        public async Task<Employee> GetEmpDetailsById(int? id)
        {
            using (var Context = new EmployeeLogDbContext())
            {
                return await Context.employees.FirstOrDefaultAsync(m => m.EmployeeId == id);
            }
        }


        public async Task<bool> CreateEmployee(Employee emp)
        {
            using (var Context = new EmployeeLogDbContext())
            {
                try
                {
                    Context.Add(emp);
                    await Context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task UpdateEmployee(Employee emp)
        {
            using (var Context = new EmployeeLogDbContext())
            {

                Context.Update(emp);
                await Context.SaveChangesAsync();

            }
        }

        public async Task DeleteEmployee(int id)
        {
            using (var Context = new EmployeeLogDbContext())
            {
                var emp = await Context.employees.FindAsync(id);

                Context.employees.Remove(emp);
                await Context.SaveChangesAsync();
            }
        }

        public bool EmployeeExists(int id)
        {
            using (var Context = new EmployeeLogDbContext())
            {
                return Context.employees.Any(e => e.EmployeeId == id);
                //return Context.employees.Where(e => e.EmployeeId == id).Count() > 0;
            }
        }


    }
}
