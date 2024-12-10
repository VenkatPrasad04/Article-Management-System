using AMS.DataAcessLayer.RepoInterfaces;
using AMS.Models.ArticleModels;
using AMS.Models.DashboardModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataAcessLayer.RepoInterfaceImpl
{
    public class DashboardRepo : IDashboardRepo
    {
        private readonly IDbConnection _dbConnection;
        public DashboardRepo(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public string GetCountCreated(DashboardViewModel dashboard)
        {
     
            dashboard.Created = _dbConnection.QueryFirstOrDefault<string>("getCountCreated", commandType: CommandType.StoredProcedure);
            return dashboard.Created;
        }
        public string GetCountModified(DashboardViewModel dashboard)
        {
            dashboard.Updated = _dbConnection.QueryFirstOrDefault<string>("getCountModified", commandType: CommandType.StoredProcedure);
            return dashboard.Updated;
        }
        public string GetCountDeleted(DashboardViewModel dashboard)
        {
            dashboard.Deleted = _dbConnection.QueryFirstOrDefault<string>("getCountDeleted", commandType: CommandType.StoredProcedure);
            return dashboard.Deleted;
        }
        public List<ActivityLog> Getlogmsg(DashboardViewModel dashboard)
        {
            string query = "Getlogmsg";
            return  _dbConnection.Query<ActivityLog>(query, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
