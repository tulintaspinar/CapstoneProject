using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_BusinessLayer.ValidationRules;
using CapstoneProject_DTOs.DTOs;
using CapstoneProject_EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
            return View(_articleService.GetArticleByCategory(User.Identity.Name));
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
                var typesOfWritingId = _typesOfWritingService.TGetList().Where(x => x.Name == "Article").First().TypesOfWritingID;
                var categoryID = _articleCategoryService.TGetList().Where(x => x.CategoryName == article.ArticleCategoryName && x.TypesOfWritingID == typesOfWritingId).First().ArticleCategoryID;

                if (article.Image != null)
                {
                    var extension = Path.GetExtension(article.Image.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/IMAGES/ArticleImages/", newImageName);
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
                    ImageUrl = article.ImageUrl,
                    ArticleCategoryID = categoryID
                });
                _userActivityTimelineService.Add(new UserActivityTimeline()
                {
                    WriterName = User.Identity.Name,
                    TypeOfWritingName = "Article Added",
                    Date = DateTime.Now
                }) ;
                return RedirectToAction("Index");

        }

        public IActionResult DeleteArticle(int id)
        {
            _articleService.TDelete(_articleService.TGetById(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditArticle(int id)
        {
            var value = _articleService.TGetById(id);
            ArticleEditDTO editDTO = new ArticleEditDTO()
            {
                Id=value.ArticleID,
                Title = value.Title,
                Description = value.Description,
                ImageUrl = value.ImageUrl
            };
            return View(editDTO);
        }
        [HttpPost]
        public IActionResult EditArticle(ArticleEditDTO dto)
        {
            ArticleEditValidator rules = new ArticleEditValidator();
            ValidationResult result = rules.Validate(dto);
            if(result.IsValid)
            {
                var article = _articleService.TGetById(dto.Id);

                if (dto.Image != null)
                {
                    var extension = Path.GetExtension(dto.Image.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/IMAGES/ArticleImages/", newImageName);
                    var stream = new FileStream(location, FileMode.Create);
                    dto.Image.CopyTo(stream);
                    article.ImageUrl = newImageName;
                }
                article.Title=dto.Title;
                article.Description=dto.Description;
                
                _articleService.TUpdate(article);

                _userActivityTimelineService.Add(new UserActivityTimeline()
                {
                    WriterName = User.Identity.Name,
                    TypeOfWritingName = "Article Updated",
                    Date = DateTime.Now
                });

                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
