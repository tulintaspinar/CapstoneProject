using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_BusinessLayer.CQRS.Handlers.ArticleHandlers;
using CapstoneProject_BusinessLayer.CQRS.Handlers.WriterHandlers;
using CapstoneProject_BusinessLayer.CQRS.Queries.WriterQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CapstoneProject.Areas.Homepage.Controllers
{
    [Area("Homepage")]
    [AllowAnonymous]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly GetWritersInformationQueryHandle _getWritersInformationQueryHandler;
        private readonly GetLastThreeArticleQueryHandler _getLastThreeArticleQueryHandler;

        public ArticleController(IArticleService articleService, GetWritersInformationQueryHandle getWritersInformationQueryHandler, GetLastThreeArticleQueryHandler getLastThreeArticleQueryHandler)
        {
            _articleService = articleService;
            _getWritersInformationQueryHandler = getWritersInformationQueryHandler;
            _getLastThreeArticleQueryHandler = getLastThreeArticleQueryHandler;
        }

        public IActionResult AllArticle()
        {
            var values = _articleService.GetArticleByCategory();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> ArticleDetail(int id)
        {
            var value = _articleService.TGetById(id);
           
            var user = await _getWritersInformationQueryHandler.Handle(new GetWritersInformationQuery(value.WriterName));
            ViewBag.user = user;

            ViewBag.articles = _getLastThreeArticleQueryHandler.Handle();
            return View(value);
        }

    }
}
