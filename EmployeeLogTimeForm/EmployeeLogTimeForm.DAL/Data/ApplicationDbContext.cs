using EmployeeLogTimeForm.DAL.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeLogTimeForm.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }

    public class EmployeeLogDbContext : DbContext
    {
        public EmployeeManagementDbContext()
        {
        }
        public EmployeeLogDbContext(DbContextOptions<EmployeeLogDbContext> options)
            : base(options)
        {

        }
        public DbSet<Employee> employees { get; set; }
    }
}
