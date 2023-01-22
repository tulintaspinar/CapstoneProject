using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.ViewComponents.Shortcut
{
    public class ShortcutList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
