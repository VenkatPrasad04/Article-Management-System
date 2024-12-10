using AMS.DataAcessLayer.RepoInterfaces;
using AMS.Models.LoginModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataAcessLayer.RepoInterfaceImpl
{
    
    public class RegisterRepo : IRegisterRepo
    {
        private readonly IDbConnection _dbConnection;
        public RegisterRepo(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public string RegisterUser(RegisterViewModel model)
        {
            string registeruser = "RegisterUser";
            var parameters = new
            {
                uname = model.UserName,
                Password = model.Password,
                FirstName= model.FirstName,
                LastName= model.LastName,   
                Gender= model.Gender,
            };

            //Executing the store procedure.
            string result = _dbConnection.QueryFirstOrDefault<string>(registeruser, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
