using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.ViewComponents.Navbar
{
    public class Navbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
