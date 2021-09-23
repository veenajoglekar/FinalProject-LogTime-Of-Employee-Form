using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeProject.DAL.Data.Model
{
    public class EditRoleModel
    {
        public EditRoleModel()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }
        [Required(ErrorMessage ="Role Name is required")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}
