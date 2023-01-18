using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_DTOs.DTOs;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            return View(_articleCategoryService.TGetList());
        }
        [HttpGet]
        public IActionResult Add()
        {
            var names = _typesOfWritingService.TGetList();
            List<string> typesOfWriting = new List<string>();
            foreach (var item in names)
            {
                typesOfWriting.Add(item.Name);
            }
            ViewBag.typesOfWriting=typesOfWriting;
            return View();
        }
        [HttpPost]
        public IActionResult Add(ArticleCategoriesAddDTO articleCategories)
        {
            if(ModelState.IsValid)
            {
                _articleCategoryService.TAdd(new ArticleCategory()
                {
                    CategoryName=articleCategories.CategoryName,
                    TypesOfWritingID=articleCategories.TypesOfWritingID
                });
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            _articleCategoryService.TDelete(_articleCategoryService.TGetById(id));
            return RedirectToAction("Index");
        }
    }
}
