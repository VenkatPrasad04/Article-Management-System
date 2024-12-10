using AMS.Models.DashboardModels;
using AMS.ServiceLayer.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArticleManagementSystem.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;
        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        public IActionResult Index(DashboardViewModel dashboard)
        {
            _dashboardService.CountCreated(dashboard);
            _dashboardService.CountModified(dashboard);
            _dashboardService.CountDeleted(dashboard);
            dashboard.Activity = _dashboardService.Getlogs(dashboard);
            return View("Dashboard",dashboard);
        }
    }
}
