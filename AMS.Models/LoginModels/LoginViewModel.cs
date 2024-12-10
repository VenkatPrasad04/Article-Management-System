using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Models.LoginModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "UserName is Mandatory")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Mandatory")]
        public string Password { get; set; }

    }
}
