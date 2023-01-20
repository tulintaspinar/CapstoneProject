using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Account()
        {
            return View();
        }
    }
}
