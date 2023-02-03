using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Areas.Homepage.Controllers
{
    [Area("Homepage")]
    [AllowAnonymous]
    public class ArticleController : Controller
    {
        public IActionResult AllArticle()
        {
            return View();
        }
    }
}
