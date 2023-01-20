using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
