using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Controllers
{
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
