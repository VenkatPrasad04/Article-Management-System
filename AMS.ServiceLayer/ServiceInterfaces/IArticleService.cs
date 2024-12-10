﻿
using AMS.Models.ArticleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ServiceLayer.ServiceInterfaces
{
    public interface IArticleService
    {
        List<ArticleViewModel> GetArticles(ArticleViewModel article, UserData userData);
        string AddArticle(ArticleViewModel article, UserData userData);
        string UpdateArticle(ArticleViewModel article,UserData userData);
        string DeleteArticle(ArticleViewModel article,UserData userData);
        
        
    }
}