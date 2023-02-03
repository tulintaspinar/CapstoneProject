using CapstoneProject_BusinessLayer.CQRS.Results.ArticleCategoriesResults;
using CapstoneProject_BusinessLayer.CQRS.Results.NewsArticleResults;
using CapstoneProject_DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.CQRS.Handlers.NewsArticleHandlers
{
    public class GetFiveNewsArticleQueryHandler
    {
        private readonly Context _context;

        public GetFiveNewsArticleQueryHandler(Context context)
        {
            _context = context;
        }
        public List<GetNewsArticleQueryResult> Handle()
        {
            var values = _context.NewsArticles.Select(x => new GetNewsArticleQueryResult
            {
                Id = x.NewsArticleID,
                ArticleCategory = x.ArticleCategory,
                ArticleCategoryID = x.ArticleCategoryID,
                Date = x.Date,
                ImageUrl = x.ImageUrl,
                Title = x.Title,
                WriterName = x.WriterName
            }).AsNoTracking().Take(5).ToList();
            return values;
        }
    }
}
