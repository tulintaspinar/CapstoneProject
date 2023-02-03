using CapstoneProject_BusinessLayer.CQRS.Handlers.ArticlecategoriesHandlers;
using CapstoneProject_BusinessLayer.CQRS.Handlers.NewsArticleHandlers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CapstoneProject.Areas.Homepage.ViewComponents.HomePageNewsArticle
{
    public class HomePageNewsArticle : ViewComponent
    {
        private readonly GetThreeNewsArticleCategoriesQueryHandler _getThreeNewsArticleCategoriesQueryHandler;
        private readonly GetNewsArticleQueryHandler _getNewsArticleQueryHandler;

        public HomePageNewsArticle(GetThreeNewsArticleCategoriesQueryHandler getThreeNewsArticleCategoriesQueryHandler, GetNewsArticleQueryHandler getNewsArticleQueryHandler)
        {
            _getThreeNewsArticleCategoriesQueryHandler = getThreeNewsArticleCategoriesQueryHandler;
            _getNewsArticleQueryHandler = getNewsArticleQueryHandler;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.Categories = _getThreeNewsArticleCategoriesQueryHandler.Handle();

            return View(_getNewsArticleQueryHandler.Handle());
        }
    }
}
