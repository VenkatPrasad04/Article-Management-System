using AMS.Models.ArticleModels;
using AMS.Models.DashboardModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceLayer.ServiceInterfaces
{
    public interface IDashboardService
    {
        public string CountCreated(DashboardViewModel dashboard);
        public string CountModified(DashboardViewModel dashboard);
        public string CountDeleted(DashboardViewModel dashboard);
        public List<ActivityLog> Getlogs(DashboardViewModel dashboard);
    }
}
