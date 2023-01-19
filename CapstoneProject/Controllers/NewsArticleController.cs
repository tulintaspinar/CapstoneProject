using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_DTOs.DTOs;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapstoneProject.Controllers
{
    public class NewsArticleController : Controller
    {
        private readonly INewsArticleService _newsArticleService;
        private readonly IArticleCategoryService _articleCategoryService;
        private readonly ITypesOfWritingService _typesOfWritingService;

        public NewsArticleController(INewsArticleService newsArticleService, IArticleCategoryService articleCategoryService, ITypesOfWritingService typesOfWritingService)
        {
            _newsArticleService = newsArticleService;
            _articleCategoryService = articleCategoryService;
            _typesOfWritingService = typesOfWritingService;
        }

        public IActionResult Index()
        {
            return View(_newsArticleService.GetNewsArticleByCategory());
        }
        [HttpGet]
        public IActionResult Add()
        {
            var id = _typesOfWritingService.TGetList().Where(x => x.Name == "News Article").First().TypesOfWritingID; //News article id'si alındı
            var newsArticleCategories = _articleCategoryService.TGetList().Where(x => x.TypesOfWritingID == id); //news article'ye ait kategoriler listelenir.
            List<string> categories = new List<string>();
            foreach (var item in newsArticleCategories)
            {
                if(!categories.Equals(item.CategoryName))
                    categories.Add(item.CategoryName);
            }
            ViewBag.categories = categories;
            return View();
        }
        [HttpPost]
        public IActionResult Add(NewsArticleAddDTO newsArticle)
        {
            if (ModelState.IsValid)
            {
                _newsArticleService.TAdd(new NewsArticle()
                {
                    Title=newsArticle.Title,
                    Description=newsArticle.Description,
                    Date=DateTime.Now
                    //WriterName=User.Identity.Name,
                    //ImageUrl=newsArticle.ImageUrl,
                    //ArticleCategoryID = newsArticle.ArticleCategoryID
                });
                return RedirectToAction("Index");
            }
            return View();  
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

            return View(_newsArticleService.TGetById(id));
        }
        [HttpPost]
        public IActionResult Edit(NewsArticleEditDTO newsArticle)
        {
            if (ModelState.IsValid)
            {
                _newsArticleService.TUpdate(new NewsArticle()
                {
                    NewsArticleID = newsArticle.ID,
                    Title = newsArticle.Title,
                    Description = newsArticle.Description
                    //ImageUrl = newsArticle.ImageUrl,
                    //ArticleCategoryID = newsArticle.ArticleCategoryID
                });
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
