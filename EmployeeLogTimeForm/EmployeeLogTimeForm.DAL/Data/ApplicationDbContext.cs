using EmployeeLogTimeForm.DAL.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeLogTimeForm.DAL.Data
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
        public EmployeeLogDbContext()
        {
        }
        public EmployeeLogDbContext(DbContextOptions<EmployeeLogDbContext> options)
            : base(options)
        {

        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<ProjectInfo> projectInfo { get; set; }
        public DbSet<JobInfo> jobInfo { get; set; }
        public DbSet<LogTimeForm> logTimeForm { get; set; }
        public DbSet<AssignUser> AssignUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=VEENAJ\\SQLEXPRESS;Database=EmployeeLogTime;User Id=sa;password=123;MultipleActiveResultSets=True");
            }
        }
    }
}
