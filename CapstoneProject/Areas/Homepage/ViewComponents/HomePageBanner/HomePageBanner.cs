using CapstoneProject_BusinessLayer.CQRS.Handlers.ArticleHandlers;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapstoneProject.Areas.Homepage.ViewComponents.HomePageBanner
{
    public class HomePageBanner : ViewComponent
    {
        private readonly GetLastThreeArticleQueryHandler _getLastThreeArticleQueryHandler;
        private readonly UserManager<AppUser> _userManager;

        public HomePageBanner(GetLastThreeArticleQueryHandler getLastThreeArticleQueryHandler, UserManager<AppUser> userManager)
        {
            _getLastThreeArticleQueryHandler = getLastThreeArticleQueryHandler;
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = _getLastThreeArticleQueryHandler.Handle();
            for (int i = 0; i < values.Count; i++)
            {
                var user = await _userManager.FindByNameAsync(values[i].WriterName);
                values[i].WriterImageUrl = user.Image;
            }
            return View(values);
        }
    }
}
