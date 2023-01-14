using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(int a)
        {
            return RedirectToAction("EmailConfirm");
        }

        [HttpGet]
        public IActionResult EmailConfirm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EmailConfirm(int a)
        {
            return RedirectToAction("Index","Login");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ForgotPassword(int a)
        {
            return View();
        }
    }
}
