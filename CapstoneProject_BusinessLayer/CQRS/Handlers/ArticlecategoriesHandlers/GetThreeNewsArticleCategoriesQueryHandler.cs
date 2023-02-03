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
    public class GetThreeNewsArticleCategoriesQueryHandler
    {
        private readonly Context _context;

        public GetThreeNewsArticleCategoriesQueryHandler(Context context)
        {
            _context = context;
        }
        public List<GetThreeNewsArticleCategoriesQueryResult> Handle()
        {
            var values = _context.ArticleCategories.Where(x => x.TypesOfWritingID == 4).Select(x => new GetThreeNewsArticleCategoriesQueryResult
            {
                CategoryName = x.CategoryName
            }).AsNoTracking().Take(3).ToList();
            return values;
        }
    }
}
