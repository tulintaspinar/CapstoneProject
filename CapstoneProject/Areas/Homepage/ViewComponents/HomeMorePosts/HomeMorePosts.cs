using CapstoneProject_BusinessLayer.CQRS.Handlers.ArticleHandlers;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Areas.Homepage.ViewComponents.HomeMorePosts
{
    public class HomeMorePosts : ViewComponent
    {
        private readonly GetTwoArticleQueryHandler _getTwoArticleQueryHandler;
        private readonly UserManager<AppUser> _userManager;

        public HomeMorePosts(GetTwoArticleQueryHandler getTwoArticleQueryHandler, UserManager<AppUser> userManager)
        {
            _getTwoArticleQueryHandler = getTwoArticleQueryHandler;
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = _getTwoArticleQueryHandler.Handle();
            for (int i = 0; i < values.Count; i++)
            {
                var user = await _userManager.FindByNameAsync(values[i].WriterName);
                values[i].WriterImageUrl = user.Image;
            }
            return View(values);
        }
    }
}
