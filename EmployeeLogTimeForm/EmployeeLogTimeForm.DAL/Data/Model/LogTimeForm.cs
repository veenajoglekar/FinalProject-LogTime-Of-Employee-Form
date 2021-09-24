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

        public int ClientId { get; set; }
        public int ProjectId { get; set; }
        public int JobId { get; set; }

        [ForeignKey(nameof(ClientId))]
        [InverseProperty("LogTimeForm")]
        [Display(Name = "Client Name")]
        public virtual Client Client { get; set; }

        [ForeignKey(nameof(ProjectId))]
        [InverseProperty("LogTimeForm")]
        [Display(Name = "Project Name")]
        public virtual ProjectInfo ProjectInfo { get; set; }

        [ForeignKey(nameof(JobId))]
        [InverseProperty("LogTimeForm")]
        [Display(Name = "Job Name")]
        public virtual JobInfo JobInfo { get; set; }

        public string WorkItem { get; set; }
        public DateTime? Date { get; set; }

        public string Description { get; set; }

        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public override string ToString()
        {
            return String.Format(
                "{0:00}:{1:00}:{2:00}",
                this.Hours, this.Minutes, this.Seconds);
        }
        
    }
}
