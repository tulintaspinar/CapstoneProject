using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
