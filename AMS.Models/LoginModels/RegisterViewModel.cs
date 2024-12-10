using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Models.LoginModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First Name is required")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "First Name should contain only alphabets")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Last Name should contain only alphabets")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Your Email is not valid.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Gender should be selected")]
        public GenderType Gender { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password should be at least 6 characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }

    public enum GenderType
    {
        SelectGender,
        Male,
        Female,
        Other
    }
}

