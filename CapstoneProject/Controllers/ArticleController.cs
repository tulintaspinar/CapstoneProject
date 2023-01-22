using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_DTOs.DTOs;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CapstoneProject.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ITypesOfWritingService _typesOfWritingService;
        private readonly IArticleCategoryService _articleCategoryService;
        private readonly IUserActivityTimelineService _userActivityTimelineService;

        public ArticleController(IArticleService articleService, ITypesOfWritingService typesOfWritingService, IArticleCategoryService articleCategoryService, IUserActivityTimelineService userActivityTimelineService)
        {
            _articleService = articleService;
            _typesOfWritingService = typesOfWritingService;
            _articleCategoryService = articleCategoryService;
            _userActivityTimelineService = userActivityTimelineService;
        }

        public IActionResult Index()
        {
            return View(_articleService.GetArticleByCategory());
        }

        [HttpGet]
        public IActionResult AddArticle()
        {
            var id = _typesOfWritingService.TGetList().Where(x => x.Name == "Article").First().TypesOfWritingID; //article id'si alındı
            var newsArticleCategories = _articleCategoryService.TGetList().Where(x => x.TypesOfWritingID == id); //article'ye ait kategoriler listelenir.
            List<string> categories = new List<string>();
            foreach (var item in newsArticleCategories)
            {
                if (!categories.Equals(item.CategoryName))
                    categories.Add(item.CategoryName);
            }
            ViewBag.categories = categories;
            return View();
        }
        [HttpPost]
        public IActionResult AddArticle(ArticleAddDTO article)
        {
            if (ModelState.IsValid)
            {
                var typesOfWritingId = _typesOfWritingService.TGetList().Where(x => x.Name == "Article").First().TypesOfWritingID;
                var categoryID = _articleCategoryService.TGetList().Where(x => x.CategoryName == article.ArticleCategoryName && x.TypesOfWritingID == typesOfWritingId).First().ArticleCategoryID;

                if (article.Image != null)
                {
                    var extension = Path.GetExtension(article.Image.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory()+"/wwwroot/IMAGES/ArticleImages/",newImageName);
                    var stream = new FileStream(location, FileMode.Create);
                    article.Image.CopyTo(stream);
                    article.ImageUrl = newImageName;
                }

                _articleService.TAdd(new Article()
                {
                    Date = DateTime.Now,
                    Title = article.Title,
                    Description = article.Description,
                    WriterName = User.Identity.Name,
                    ImageUrl=article.ImageUrl,
                    ArticleCategoryID=categoryID
                });
                _userActivityTimelineService.Add(new UserActivityTimeline()
                {
                    TypeOfWritingName="Article Added",
                    Date= DateTime.Now
                });
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult DeleteArticle(int id)
        {
            _articleService.TDelete(_articleService.TGetById(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditArticle(int id)
        {
            return View(_articleService.TGetById(id));
        }
        [HttpPost]
        public IActionResult EditArticle(ArticleEditDTO dto)
        {
            return RedirectToAction("Index");
        }
    }
}
