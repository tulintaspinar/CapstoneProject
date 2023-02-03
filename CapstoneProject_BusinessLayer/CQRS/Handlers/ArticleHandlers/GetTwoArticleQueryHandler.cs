using CapstoneProject_BusinessLayer.CQRS.Results.ArticleResults;
using CapstoneProject_DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.CQRS.Handlers.ArticleHandlers
{
    public class GetTwoArticleQueryHandler
    {
        private readonly Context _context;

        public GetTwoArticleQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetArticleQueryResult> Handle()
        {
            var values = _context.Articles.Include(x => x.ArticleCategory).Select(x => new GetArticleQueryResult
            {
                ArticleCategory = x.ArticleCategory,
                ArticleCategoryID = x.ArticleCategory.ArticleCategoryID,
                Title = x.Title,
                Date = x.Date,
                ImageUrl = x.ImageUrl,
                WriterName = x.WriterName
            }).AsNoTracking().Take(2).ToList();
            return values;
        }
    }
}
