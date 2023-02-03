using CapstoneProject_BusinessLayer.CQRS.Results.ArticleCategoriesResults;
using CapstoneProject_DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.CQRS.Handlers.ArticlecategoriesHandlers
{
    public class GetFiveArticleCategoriesQueryHandler
    {
        private readonly Context _context;

        public GetFiveArticleCategoriesQueryHandler(Context context)
        {
            _context = context;
        }
        public List<GetArticleCategoriesQueryResult> Handle()
        {
            var values = _context.ArticleCategories.Where(x => x.TypesOfWritingID == 3).Select(x => new GetArticleCategoriesQueryResult
            {
                CategoryName = x.CategoryName
            }).Take(5).AsNoTracking().ToList();
            return values;
        }
    }
}
