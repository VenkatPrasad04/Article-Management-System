using AMS.DataAcessLayer.RepoInterfaces;
using AMS.Models.ArticleModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace AMS.DataAcessLayer.RepoInterfaceImpl
{
    public class ArticleRepo : IArticleRepo
    {
        private readonly IDbConnection _dbConnection;
        public ArticleRepo(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public List<ArticleViewModel> GetArticles(ArticleViewModel article, UserData userData)
        {

            _dbConnection.Open();
            string query = "GetArticles";
            var datalist = _dbConnection.Query<ArticleViewModel>(query, commandType: CommandType.StoredProcedure);

            return datalist.ToList();

        }

        public string AddArticle(ArticleViewModel article, UserData userData)
        {
            string flag = "True";
            string query = "ArticleCreate";
            var parameter = new
            {
                ArticleName = article.ArticleName,
                ArticleContent = article.ArticleContent,
                uId = userData.Userid
            };

            var status = _dbConnection.QueryFirstOrDefault<string>(query, parameter, commandType: CommandType.StoredProcedure);
            if (status == "-1")
            {
                flag = "False";
            }
            else
            {
                LogActivity("Created", userData.Userid);
                Log("Created", article.ArticleName,userData.Userid);
            }


            return flag;
        }

        public string UpdateArticle(ArticleViewModel article, UserData userData)
        {
            string flag = "True";
            string query = "ArticleUpdate";
            var parameter = new
            {
                ArticleName = article.ArticleName,
                ArticleContent = article.ArticleContent,
                uId = userData.Userid
            };

            var status = _dbConnection.QueryFirstOrDefault<string>(query, parameter, commandType: CommandType.StoredProcedure);
            if (status == "-1")
            {
                flag = "False";
            }
            else
            {
                LogActivity("Modified", userData.Userid);
                Log("Modified", article.ArticleName, userData.Userid);
            }

            return flag;
        }

        public string DeleteArticle(ArticleViewModel article, UserData userData)
        {
            string flag = "True";
            string query = "ArticleDelete";
            var parameter = new
            {
                ArticleName = article.ArticleName,
                uId = userData.Userid
            };

            var status = _dbConnection.QueryFirstOrDefault<string>(query, parameter, commandType: CommandType.StoredProcedure);
            if (status == "-1")
            {
                flag = "False";
            }
            else
            {
                LogActivity("Deleted", userData.Userid);
                Log("Deleted",article.ArticleName, userData.Userid);
                
            }
            
            return flag;
        }

        private void LogActivity(string action, string uId)
        {
            string activityLogQuery = "InsertActivity";

            var logParameter = new
            {
                Action = action,
                uId = uId
            };

            _dbConnection.Execute(activityLogQuery, logParameter, commandType: CommandType.StoredProcedure);
        }
        private void Log(string action,string articleName,string uId)
        {
            string getUsernameQuery = "SELECT FirstName FROM Users WHERE uId = @uId";
            string username = _dbConnection.QueryFirstOrDefault<string>(getUsernameQuery, new { uId = uId });
            
            string activityLogQuery = "InsertActivityLog";
            string logMessage = $"Article {articleName} {action.ToLower()} by {username} on {DateTime.Now.ToString("MM/dd/yyyy")}.";

            var logParameter = new
            {
                LogMessage= logMessage
            };

             _dbConnection.Execute(activityLogQuery, logParameter, commandType: CommandType.StoredProcedure);
            
        }
    }
}
