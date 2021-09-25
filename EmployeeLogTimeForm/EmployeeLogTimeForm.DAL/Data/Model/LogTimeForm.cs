using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeLogTimeForm.DAL.Data.Model
{
    public class LogTimeForm
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int JobId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        [Display(Name = "Project Name")]
        public virtual ProjectInfo ProjectInfo { get; set; }

        [ForeignKey(nameof(JobId))]
        [Display(Name = "Job Name")]

        [InverseProperty("LogTimeForm")]

        public virtual JobInfo JobInfo { get; set; }

        public string WorkItem { get; set; }
        public DateTime? Date { get; set; }

        public string Description { get; set; }

        public string Hours { get; set; }
    }
}
