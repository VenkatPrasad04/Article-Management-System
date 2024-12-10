using AMS.Models.LoginModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceLayer.ServiceInterfaces
{
    public interface ILoginService
    {
        string GetUserName(LoginViewModel model);
    }
}
