using AMS.DataAcessLayer.RepoInterfaces;
using AMS.Models.LoginModels;
using AMS.ServiceLayer.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceLayer.ServiceInterfaceImpl
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepo _loginRepo;
        public LoginService(ILoginRepo loginRepo)
        {
            _loginRepo = loginRepo;
        }
        public string GetUserName(LoginViewModel model)
        {
            //throw new NotImplementedException();
            return _loginRepo.GetUserName(model);
        }
    }
}
