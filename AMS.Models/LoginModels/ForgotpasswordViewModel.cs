using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Models.LoginModels
{
    public class ForgotpasswordViewModel
    {
        [Required(ErrorMessage = "UserName is Mandatory")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Your Email is not valid.")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Password is Mandatory")]
        [MinLength(6, ErrorMessage = "Password should be at least 6 characters long")]
        public string Password { get; set; }
    }
}
