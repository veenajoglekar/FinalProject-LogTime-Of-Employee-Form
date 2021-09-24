using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeLogTimeForm.DAL.Data.Model
{
    public class JobInfo
    {
        public JobInfo()
        {
            LogTimeForm = new HashSet<LogTimeForm>();
        }
        [Key]
        public int JobId { get; set; }
        public string JobName { get; set; }
        [InverseProperty("JobInfo")]
        public virtual ICollection<LogTimeForm> LogTimeForm { get; set; }
    }
}
