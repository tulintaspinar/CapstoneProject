using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_BusinessLayer.ValidationRules;
using CapstoneProject_DTOs.DTOs;
using CapstoneProject_EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CapstoneProject.Controllers
{
    public class NewsArticleController : Controller
    {
        private readonly INewsArticleService _newsArticleService;
        private readonly IArticleCategoryService _articleCategoryService;
        private readonly ITypesOfWritingService _typesOfWritingService;
        private readonly IUserActivityTimelineService _userActivityTimelineService;

        public NewsArticleController(INewsArticleService newsArticleService, IArticleCategoryService articleCategoryService, ITypesOfWritingService typesOfWritingService, IUserActivityTimelineService userActivityTimelineService)
        {
            _newsArticleService = newsArticleService;
            _articleCategoryService = articleCategoryService;
            _typesOfWritingService = typesOfWritingService;
            _userActivityTimelineService = userActivityTimelineService;
        }

        public IActionResult Index()
        {
            return View(_newsArticleService.GetNewsArticleByCategory(User.Identity.Name));
        }
        [HttpGet]
        public IActionResult Add()
        {
            var id = _typesOfWritingService.TGetList().Where(x => x.Name == "News Article").First().TypesOfWritingID; //News article id'si alındı
            var newsArticleCategories = _articleCategoryService.TGetList().Where(x => x.TypesOfWritingID == id); //news article'ye ait kategoriler listelenir.
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
        public IActionResult Add(NewsArticleAddDTO newsArticle)
        {
            var typesOfWritingId = _typesOfWritingService.TGetList().Where(x => x.Name == "News Article").First().TypesOfWritingID;
            var categoryID = _articleCategoryService.TGetList().Where(x => x.CategoryName == newsArticle.ArticleCategoryName && x.TypesOfWritingID == typesOfWritingId).First().ArticleCategoryID;

            if (newsArticle.Image != null)
            {
                var extension = Path.GetExtension(newsArticle.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/IMAGES/NewsArticleImages/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                newsArticle.Image.CopyTo(stream);
                newsArticle.ImageUrl = newImageName;
            }

            _newsArticleService.TAdd(new NewsArticle()
            {
                Title = newsArticle.Title,
                Description = newsArticle.Description,
                Date = DateTime.Now,
                WriterName = User.Identity.Name,
                ImageUrl = newsArticle.ImageUrl,
                ArticleCategoryID = categoryID
            });
            _userActivityTimelineService.Add(new UserActivityTimeline()
            {
                WriterName = User.Identity.Name,
                TypeOfWritingName = "News article Added",
                Date = DateTime.Now
            });

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _newsArticleService.TDelete(_newsArticleService.TGetById(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var TypesOfWritingID = _typesOfWritingService.TGetList().Where(x => x.Name == "News Article").First().TypesOfWritingID; //News article id'si alındı
            var newsArticleCategories = _articleCategoryService.TGetList().Where(x => x.TypesOfWritingID == TypesOfWritingID); //news article'ye ait kategoriler listelenir.
            List<string> categories = new List<string>();
            foreach (var item in newsArticleCategories)
            {
                if (!categories.Equals(item.CategoryName))
                    categories.Add(item.CategoryName);
            }
            ViewBag.categories = categories;
            var newsArticle = _newsArticleService.TGetById(id);
            return View(new NewsArticleEditDTO
            {
                Title= newsArticle.Title,
                Description= newsArticle.Description

            });
        }
        [HttpPost]
        public IActionResult Edit(NewsArticleEditDTO newsArticle)
        {
            var typesOfWritingId = _typesOfWritingService.TGetList().Where(x => x.Name == "News Article").First().TypesOfWritingID;
            var categoryID = _articleCategoryService.TGetList().Where(x => x.CategoryName == newsArticle.ArticleCategoryName && x.TypesOfWritingID == typesOfWritingId).First().ArticleCategoryID;


            if (newsArticle.Image != null)
            {
                var extension = Path.GetExtension(newsArticle.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/IMAGES/NewsArticleImages/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                newsArticle.Image.CopyTo(stream);
                newsArticle.ImageUrl = newImageName;
            }

            _newsArticleService.TUpdate(new NewsArticle()
            {
                NewsArticleID = newsArticle.ID,
                Title = newsArticle.Title,
                Description = newsArticle.Description,
                ImageUrl = newsArticle.ImageUrl,
                WriterName=User.Identity.Name,
                ArticleCategoryID = categoryID
            });

            _userActivityTimelineService.Add(new UserActivityTimeline()
            {
                WriterName = User.Identity.Name,
                TypeOfWritingName = "News article Updated",
                Date = DateTime.Now
            });

            return RedirectToAction("Index");
        }
    }
}
