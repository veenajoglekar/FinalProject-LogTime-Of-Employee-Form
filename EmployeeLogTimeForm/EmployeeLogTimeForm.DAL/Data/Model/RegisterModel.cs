using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeLogTimeForm.DAL.Data.Model
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="confirm password")]
        [Compare("Password",
            ErrorMessage = " Password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
