using AMS.DataAcessLayer.RepoInterfaceImpl;
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
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterRepo _registerRepo;
        public RegisterService(IRegisterRepo registerRepo)
        {
            _registerRepo = registerRepo;
        }
        public string RegisterUser(RegisterViewModel model)
        {
            //throw new NotImplementedException();
            return _registerRepo.RegisterUser(model);
        }
    }
}
