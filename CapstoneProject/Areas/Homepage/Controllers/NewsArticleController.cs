using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_BusinessLayer.CQRS.Handlers.ArticleHandlers;
using CapstoneProject_BusinessLayer.CQRS.Handlers.NewsArticleHandlers;
using CapstoneProject_BusinessLayer.CQRS.Handlers.WriterHandlers;
using CapstoneProject_BusinessLayer.CQRS.Queries.WriterQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CapstoneProject.Areas.Homepage.Controllers
{
    [Area("Homepage")]
    [AllowAnonymous]
    public class NewsArticleController : Controller
    {
        private readonly INewsArticleService _newsArticleService;
        private readonly GetWritersInformationQueryHandle _getWritersInformationQueryHandle;
        private readonly GetFiveNewsArticleQueryHandler _getFiveNewsArticleQueryHandler;

        public NewsArticleController(INewsArticleService newsArticleService, GetWritersInformationQueryHandle getWritersInformationQueryHandle, GetFiveNewsArticleQueryHandler getFiveNewsArticleQueryHandler)
        {
            _newsArticleService = newsArticleService;
            _getWritersInformationQueryHandle = getWritersInformationQueryHandle;
            _getFiveNewsArticleQueryHandler = getFiveNewsArticleQueryHandler;
        }

        public IActionResult AllNewsArticle()
        {
            var values = _newsArticleService.GetNewsArticleByCategory();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> NewsArticleDetail(int id)
        {
            var value = _newsArticleService.TGetById(id);

            var user = await _getWritersInformationQueryHandle.Handle(new GetWritersInformationQuery(value.WriterName));
            ViewBag.user = user;

            ViewBag.newsArticles = _getFiveNewsArticleQueryHandler.Handle();
            return View(value);
        }
    }
}
