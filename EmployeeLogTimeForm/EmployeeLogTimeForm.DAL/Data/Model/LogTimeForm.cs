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

        public string UserId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        [Display(Name = "Project Name")]
        public virtual ProjectInfo ProjectInfo { get; set; }

        [ForeignKey(nameof(JobId))]
        [Display(Name = "Job Name")]

        [InverseProperty("LogTimeForm")]

        [Required]
        public virtual JobInfo JobInfo { get; set; }

        [Required]
        public string WorkItem { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter Total hours")]
        public string Hours { get; set; }
        public string BillableStatus { get; set; }
    }
}
