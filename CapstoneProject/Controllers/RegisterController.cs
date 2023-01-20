using CapstoneProject_DTOs.DTOs;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CapstoneProject.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterDTO register)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    Name = register.Name,
                    Surname = register.Surname,
                    Email = register.Email,
                    UserName = register.UserName,
                    NormalizedUserName = register.UserName.ToUpper()

                };
                var result = await _userManager.CreateAsync(appUser, register.Password);
                if(result.Succeeded)
                    return RedirectToAction("Index","Login");
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
            //return RedirectToAction("EmailConfirm");
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
