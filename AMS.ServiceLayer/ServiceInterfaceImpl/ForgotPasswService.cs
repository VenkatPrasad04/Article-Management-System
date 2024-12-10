using AMS.DataAcessLayer.RepoInterfaceImpl;
using AMS.DataAcessLayer.RepoInterfaces;
using AMS.Models.LoginModels;
using AMS.ServiceLayer.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceLayer.ServiceInterfaceImpl
{
    public class ForgotPasswService : IForgotPasswService
    {
        private readonly IForgotPasswRepo _forgotPasswRepo;
        public ForgotPasswService(IForgotPasswRepo forgotPasswRepo)
        {
            _forgotPasswRepo = forgotPasswRepo;
        }
        public string ResetPassword(ForgotpasswordViewModel model)
        {
            return _forgotPasswRepo.ResetPassword(model);
        }
    }
}
