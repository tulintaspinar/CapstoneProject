using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
