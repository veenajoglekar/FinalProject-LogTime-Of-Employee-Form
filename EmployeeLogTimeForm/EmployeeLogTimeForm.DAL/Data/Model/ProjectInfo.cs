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
        }
        [Key]
        public int ProjectId { get; set; }
        public string ClientName { get; set; }
        public string ProjectName { get; set; }
        public DateTime? DueDate { get; set; }
        public string BillableStatus { get; set; }
        public int Costing { get; set; }

        [InverseProperty("ProjectInfo")]
        public virtual ICollection<LogTimeForm> LogTimeForm { get; set; }
    }
}
