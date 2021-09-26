using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeLogTimeForm.DAL.Data.Model
{
    public class AssignUser
    {
        [Key]
        public int AssignId { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        [Display(Name = "Project Name")]
        public virtual ProjectInfo ProjectInfo { get; set; }

        public string  UserId { get; set; }
    }
}
