using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_DTOs.DTOs;
using CapstoneProject_EntityLayer.Concrete;
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
                var typesOfWritingId = _typesOfWritingService.TGetList().Where(x=>x.Name==articleCategories.TypesOfWritingName).FirstOrDefault().TypesOfWritingID;
                _articleCategoryService.TAdd(new ArticleCategory()
                {
                    CategoryName = articleCategories.CategoryName,
                    TypesOfWritingID = typesOfWritingId
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

        [HttpGet]
        public IActionResult Update(int id)
        {
            var list = _articleCategoryService.TGetById(id);
            ViewBag.typesOfWriting = _typesOfWritingService.TGetById(list.TypesOfWritingID).Name; //seçili olanı yazdırmak için
            
            List<string> typesOfWriting = new List<string>();
            foreach (var item in _typesOfWritingService.TGetList())
            {
                typesOfWriting.Add(item.Name);
            }
            ViewBag.typesOfWritingAll = typesOfWriting;//dropdownlist için

            return View(list);
        }
        [HttpPost]
        public IActionResult Update(ArticleCategory article)
        {

            return RedirectToAction("Index");
        }
    }
}
