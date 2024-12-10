using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Models.DashboardModels
{
    public class DashboardViewModel
    {
        public string Created { get; set; }
        public string Updated { get; set; }
        public string Deleted { get; set; }
        public List<ActivityLog> Activity { get; set; }
    }

    public class ActivityLog
    {
        public int Id { get; set; }
        public string LogMessage { get; set; }
    }
}
