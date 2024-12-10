using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Models.ArticleModels
{
    public class ArticleViewModel
    {
        
        public int ArticleId { get; set; }
        public string ArticleName { get; set; }
        public string ArticleContent { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public string ModifiedOn { get; set; }
        public string CreatedOn { get; set; }

    }
}
