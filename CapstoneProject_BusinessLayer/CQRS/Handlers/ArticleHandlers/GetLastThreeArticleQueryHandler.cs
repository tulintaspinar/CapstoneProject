using CapstoneProject_BusinessLayer.CQRS.Results.ArticleResults;
using CapstoneProject_DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CapstoneProject_BusinessLayer.CQRS.Handlers.ArticleHandlers
{
    public class GetLastThreeArticleQueryHandler
    {
        private readonly Context _context;

        public GetLastThreeArticleQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetArticleQueryResult> Handle()
        {
            var values = _context.Articles.Include(x => x.ArticleCategory).Select(x => new GetArticleQueryResult
            {
                Id = x.ArticleID,
                ArticleCategory = x.ArticleCategory,
                ArticleCategoryID = x.ArticleCategory.ArticleCategoryID,
                Title = x.Title,
                Date = x.Date,
                ImageUrl = x.ImageUrl,
                WriterName = x.WriterName
            }).AsNoTracking().OrderByDescending(x => x.Date).Take(3).ToList();
            return values;
        }
    }
}
