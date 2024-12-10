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
    public class ForgotPasswRepo : IForgotPasswRepo
    {
        private readonly IDbConnection _dbConnection;
        public ForgotPasswRepo(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public string ResetPassword(ForgotpasswordViewModel model)
        {
            string forgotpassword = "ResetPass";
            var parameters = new
            {
                uname = model.UserName,
                Password = model.Password
            };
            string result = _dbConnection.QueryFirstOrDefault<string>(forgotpassword, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
