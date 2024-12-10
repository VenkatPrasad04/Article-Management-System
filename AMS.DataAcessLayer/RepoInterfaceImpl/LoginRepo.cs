using AMS.DataAcessLayer.RepoInterfaces;
using AMS.Models.LoginModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;


namespace AMS.DataAcessLayer.RepoInterfaceImpl
{
    public class LoginRepo : ILoginRepo
    {
        private readonly IDbConnection _dbConnection;
        public LoginRepo(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public string GetUserName(LoginViewModel model)

        {
            _dbConnection.Open();

            string validateuser = "GetUser";
            var parameters = new
            {
                uname = model.UserName,
                Password = model.Password
            };

            //Executing the store procedure.
            string result = _dbConnection.QueryFirstOrDefault<string>(validateuser, parameters, commandType: CommandType.StoredProcedure);
            return result;

            _dbConnection.Close();

        }
    }
}
