using AMS.Models.ArticleModels;
using AMS.Models.DashboardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataAcessLayer.RepoInterfaces
{
    public interface IDashboardRepo
    {
        public string GetCountCreated(DashboardViewModel dashboard);
        public string GetCountModified(DashboardViewModel dashboard);
        public string GetCountDeleted(DashboardViewModel dashboard);
        List<ActivityLog> Getlogmsg(DashboardViewModel dashboard);
    }
}
