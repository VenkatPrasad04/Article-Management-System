using AMS.DataAcessLayer.RepoInterfaces;
using AMS.Models.ArticleModels;
using AMS.ServiceLayer.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceLayer.ServiceInterfaceImpl
{
    public class ArticleService:IArticleService
    {
        private readonly IArticleRepo _articleRepo;
        public ArticleService(IArticleRepo articleRepo)
        {
            _articleRepo = articleRepo;
        }
        public List<ArticleViewModel> GetArticles(ArticleViewModel article, UserData userData)
        {
            return  _articleRepo.GetArticles(article,userData);
        }

        public string AddArticle(ArticleViewModel article,UserData userData)
        {
            // You can add business logic or validation 
           return  _articleRepo.AddArticle(article,userData);
        }

        public string UpdateArticle(ArticleViewModel article, UserData userData)
        {
            // You can add business logic or validation 
            return _articleRepo.UpdateArticle(article, userData);
        }

        public string DeleteArticle(ArticleViewModel article, UserData userData)
        {
            // You can add business logic or validation 
            return _articleRepo.DeleteArticle(article,userData);
        }
    }
}
