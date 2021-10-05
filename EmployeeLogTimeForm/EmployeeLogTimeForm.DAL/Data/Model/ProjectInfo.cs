using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeLogTimeForm.DAL.Data.Model
{
    public class ProjectInfo
    {
        public ProjectInfo()
        {
            LogTimeForm = new HashSet<LogTimeForm>();
            AssignUser = new HashSet<AssignUser>();
        }
        [Key]
        public int ProjectId { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public string ProjectName { get; set; }

        [Required]
        public DateTime? DueDate { get; set; }
        public string BillableStatus { get; set; }
        public int Costing { get; set; }

        [InverseProperty("ProjectInfo")]
        public virtual ICollection<LogTimeForm> LogTimeForm { get; set; }
        public virtual ICollection<AssignUser> AssignUser { get; set; }
    }
}
