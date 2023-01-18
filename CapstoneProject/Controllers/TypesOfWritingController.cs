using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_DTOs.DTOs;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Controllers
{
    public class TypesOfWritingController : Controller
    {
        private readonly ITypesOfWritingService _typesOfWritingService;

        public TypesOfWritingController(ITypesOfWritingService typesOfWritingService)
        {
            _typesOfWritingService = typesOfWritingService;
        }

        public IActionResult Index()
        {
            return View(_typesOfWritingService.TGetList());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(TypesOfWritingAddDTO typesOfwriting)
        {
            if(ModelState.IsValid)
            {
                _typesOfWritingService.TAdd(new TypesOfWriting()
                {
                    Name = typesOfwriting.Name
                });
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            _typesOfWritingService.TDelete(_typesOfWritingService.TGetById(id));
            return RedirectToAction("Index");
        }

    }
}
