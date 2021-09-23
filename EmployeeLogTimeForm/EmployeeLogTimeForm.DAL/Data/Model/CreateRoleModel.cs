using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeProject.DAL.Data.Model
{
    public class CreateRoleModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
