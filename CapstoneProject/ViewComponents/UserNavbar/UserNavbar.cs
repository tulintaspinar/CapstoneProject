using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CapstoneProject.ViewComponents.UserNavbar
{
    public class UserNavbar : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public UserNavbar(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.User = user.Image;
            ViewBag.UserName = user.Name + " " + user.Surname;
            return View();
        }
    }
}
