using AMS.Models.LoginModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataAcessLayer.RepoInterfaces
{
    public interface ILoginRepo
    {
        string GetUserName(LoginViewModel model);
    }
}
