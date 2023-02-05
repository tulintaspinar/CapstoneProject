using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var value = _contactService.TGetContact();
            return View(value);
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            _contactService.TUpdateContact(contact);
            return View();
        }
    }
}
