using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(int a)
        {
            return View();
        }
    }
}
