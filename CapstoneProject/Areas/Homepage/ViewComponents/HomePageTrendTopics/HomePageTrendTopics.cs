using CapstoneProject_BusinessLayer.CQRS.Handlers.ArticlecategoriesHandlers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CapstoneProject.Areas.Homepage.ViewComponents.HomePageTrendTopics
{
    public class HomePageTrendTopics : ViewComponent
    {
        private readonly GetFiveArticleCategoriesQueryHandler _getFiveArticleCategoriesQueryHandler;

        public HomePageTrendTopics(GetFiveArticleCategoriesQueryHandler getFiveArticleCategoriesQueryHandler)
        {
            _getFiveArticleCategoriesQueryHandler = getFiveArticleCategoriesQueryHandler;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_getFiveArticleCategoriesQueryHandler.Handle());
        }
    }
}
