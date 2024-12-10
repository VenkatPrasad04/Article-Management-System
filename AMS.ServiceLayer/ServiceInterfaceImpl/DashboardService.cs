using AMS.DataAcessLayer.RepoInterfaces;
using AMS.Models.DashboardModels;
using AMS.ServiceLayer.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceLayer.ServiceInterfaceImpl
{
    public class DashboardService: IDashboardService
    {
        private readonly IDashboardRepo _dashboardRepo;
        public DashboardService(IDashboardRepo dashboardRepo)
        {
            _dashboardRepo = dashboardRepo;
        }
        public string CountCreated(DashboardViewModel dashboard)
        {
            string result = _dashboardRepo.GetCountCreated(dashboard);
            return result;
        }

        public string CountModified(DashboardViewModel dashboard)
        {
            string result = _dashboardRepo.GetCountModified(dashboard);
            return result;
        }

        public string CountDeleted(DashboardViewModel dashboard)
        {
            string result = _dashboardRepo.GetCountDeleted(dashboard);
            return result;
        }
        public List<ActivityLog> Getlogs(DashboardViewModel dashboard)
        {
            return _dashboardRepo.Getlogmsg(dashboard);
        }
    }
}

