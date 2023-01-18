using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_DTOs.DTOs;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CapstoneProject.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult Index()
        {
            return View(_articleService.TGetList());
        }

        [HttpGet]
        public IActionResult AddArticle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddArticle(ArticleAddDTO article)
        {
            if (ModelState.IsValid)
            {
                _articleService.TAdd(new Article()
                {
                    Date = DateTime.Now,
                    Title = article.Title,
                    Description = article.Description,
                    WriterName = User.Identity.Name
                    //ImageUrl=article.ImageUrl,
                    //ArticleCategoryID=article.ArticleCategoryID
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
