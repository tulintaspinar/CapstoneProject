using CapstoneProject_BusinessLayer.CQRS.Handlers.NewsArticleHandlers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CapstoneProject.Areas.Homepage.ViewComponents.HomePageLastNewsArticle
{
    public class HomePageLastNewsArticle : ViewComponent
    {
        private readonly GetFiveNewsArticleQueryHandler _getFiveNewsArticleQueryHandler;

        public HomePageLastNewsArticle(GetFiveNewsArticleQueryHandler getFiveNewsArticleQueryHandler)
        {
            _getFiveNewsArticleQueryHandler = getFiveNewsArticleQueryHandler;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_getFiveNewsArticleQueryHandler.Handle());
        }
    }
}
