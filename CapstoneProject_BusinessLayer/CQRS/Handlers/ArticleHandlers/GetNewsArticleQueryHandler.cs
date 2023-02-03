using CapstoneProject_BusinessLayer.CQRS.Results.ArticleResults;
using CapstoneProject_BusinessLayer.CQRS.Results.NewsArticleResults;
using CapstoneProject_DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.CQRS.Handlers.ArticleHandlers
{
    public class GetNewsArticleQueryHandler
    {
        private readonly Context _context;

        public GetNewsArticleQueryHandler(Context context)
        {
            _context = context;
        }
        public List<GetNewsArticleQueryResult> Handle()
        {
            var values = _context.NewsArticles.Include(x => x.ArticleCategory).Select(x => new GetNewsArticleQueryResult
            {
                ArticleCategory = x.ArticleCategory,
                ArticleCategoryID = x.ArticleCategory.ArticleCategoryID,
                Title = x.Title,
                Date = x.Date,
                ImageUrl = x.ImageUrl,
                WriterName = x.WriterName
            }).AsNoTracking().Take(4).ToList();
            return values;
        }
    }
}
