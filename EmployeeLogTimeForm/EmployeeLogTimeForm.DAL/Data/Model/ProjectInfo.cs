using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeLogTimeForm.DAL.Data.Model
{
    public class ProjectInfo
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ClientName { get; set; }
        public DateTime? DueDate { get; set; }
        public string BillableStatus { get; set; }
        public int Costing { get; set; }
    }
}
