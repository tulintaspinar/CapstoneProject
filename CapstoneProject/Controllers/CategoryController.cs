using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_BusinessLayer.ValidationRules;
using CapstoneProject_DTOs.DTOs;
using CapstoneProject_EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CapstoneProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IArticleCategoryService _articleCategoryService;
        private readonly ITypesOfWritingService _typesOfWritingService;

        public CategoryController(IArticleCategoryService articleCategoryService, ITypesOfWritingService typesOfWritingService)
        {
            _articleCategoryService = articleCategoryService;
            _typesOfWritingService = typesOfWritingService;
        }

        public IActionResult Index()
        {
            return View(_articleCategoryService.TGetArticleCategoryByType());
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.typesOfWriting = TypesOfWritingList();
            return View();
        }
       
        [HttpPost]
        public IActionResult Add(ArticleCategoryAddDTO articleCategories)
        {
            ArticleCategoryAddValidator validations = new ArticleCategoryAddValidator();
            ValidationResult result = validations.Validate(articleCategories);
            if (result.IsValid)
            {
                var typesOfWritingId = _typesOfWritingService.TGetList().Where(x => x.Name == articleCategories.TypesOfWritingName).FirstOrDefault().TypesOfWritingID;
                _articleCategoryService.TAdd(new ArticleCategory()
                {
                    CategoryName = articleCategories.CategoryName,
                    TypesOfWritingID = typesOfWritingId
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
            ViewBag.typesOfWriting = TypesOfWritingList();
            return View();
        }
        public IActionResult Delete(int id)
        {
            _articleCategoryService.TDelete(_articleCategoryService.TGetById(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var list = _articleCategoryService.TGetById(id);
            var typesOfWritingId = _typesOfWritingService.TGetList().Where(x => x.TypesOfWritingID == list.TypesOfWritingID).FirstOrDefault().Name;
            ArticleCategoryEditDTO article = new ArticleCategoryEditDTO()
            {
                ID = list.TypesOfWritingID,
                CategoryName = list.CategoryName,
                TypesOfWritingName = typesOfWritingId

            };
            //dropdownlist için
            ViewBag.typesOfWritingAll = TypesOfWritingList();
            return View(article);
        }
        [HttpPost]
        public IActionResult Update(ArticleCategoryEditDTO article)
        {
            ArticleCategoryEditValidator validations = new ArticleCategoryEditValidator();
            ValidationResult result = validations.Validate(article);
            if(result.IsValid) {
                var typesOfWritingId = _typesOfWritingService.TGetList().Where(x => x.Name == article.TypesOfWritingName).FirstOrDefault().TypesOfWritingID;
                _articleCategoryService.TUpdate(new ArticleCategory()
                {
                    ArticleCategoryID = article.ID,
                    CategoryName = article.CategoryName,
                    TypesOfWritingID = typesOfWritingId
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
            ViewBag.typesOfWritingAll = TypesOfWritingList();
            return View();
        }

        public List<string> TypesOfWritingList()
        {
            var names = _typesOfWritingService.TGetList();
            List<string> typesOfWriting = new List<string>();
            foreach (var item in names)
            {
                typesOfWriting.Add(item.Name);
            }
            return typesOfWriting;
        }
    }
}
