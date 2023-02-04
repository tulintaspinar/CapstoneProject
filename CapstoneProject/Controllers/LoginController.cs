using CapstoneProject_BusinessLayer.ValidationRules;
using CapstoneProject_DTOs.DTOs;
using CapstoneProject_EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CapstoneProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUser signIn)
        {
            LoginValidator rules = new LoginValidator();
            ValidationResult result = rules.Validate(signIn);

            if(result.IsValid)
            {
                var success = await _signInManager.PasswordSignInAsync(signIn.UserName, signIn.PasswordHash, true, true);
                if (success.Succeeded)
                {
                    return RedirectToAction("Index", "AdminDashboard");
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
