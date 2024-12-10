
using AMS.Models.ArticleModels;
using AMS.ServiceLayer.ServiceInterfaceImpl;
using AMS.ServiceLayer.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArticleManagementSystem.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        // GET: ArticleController
        public ActionResult Index(UserData userData)
        {
            var Datalist =  _articleService.GetArticles(new ArticleViewModel(), userData);
            return View("Articles",Datalist);
        }

        [HttpGet]
        public IActionResult ArticleAdd(UserData userData, ArticleViewModel article)
        {
            userData.Userid = HttpContext.Session.GetString("UserId");
            return View("ArticleAdd", article);
        }


        // GET: ArticleController/Create/5
        [HttpPost]
        public IActionResult ArticleCreate([FromBody] ArticleViewModel article, UserData userData)
        {
            userData.Userid = HttpContext.Session.GetString("UserId");
            if (userData.Userid != null)
            {
                var flag = _articleService.AddArticle(article, userData);
                if (flag == "False")
                {

                    return Json(new { success = false, error = "Article alredy exiest" });
                }
                else
                {
                    return Json(new { success = true, message = "Article created successfully" });
                }
            }
            else
            {
                return Json(new { success = false, error = "User does not exist." });
            }
        }

        // GET: ArticleController/Edit/5

        [HttpPost]
        public IActionResult ArticleUpdate([FromBody] ArticleViewModel article, UserData userData)
        {
            userData.Userid = HttpContext.Session.GetString("UserId");
            if (userData.Userid != null)
            {
                var flag = _articleService.UpdateArticle(article, userData);
                if (flag == "False")
                {

                    return Json(new { success = false, error = "Article Content same" });
                }
                else
                {
                    return Json(new { success = true, message = "Article Updated successfully" });


                }
            }
            return RedirectToAction("ArticleDisplay");
        }

        // GET: ArticleController/Delete/5
        [HttpPost]
        public IActionResult DeleteArticle([FromBody] ArticleViewModel article, UserData userData)
        {
            userData.Userid = HttpContext.Session.GetString("UserId");
            var flag = _articleService.DeleteArticle(article, userData);
            if (flag == "False")
            {
                return Json(new { success = false, error = "Article not deleted" });
            }
            else
            {
                return Json(new { success = true, message = "Article Deleted successfully" });
            }
        }

    }
}
