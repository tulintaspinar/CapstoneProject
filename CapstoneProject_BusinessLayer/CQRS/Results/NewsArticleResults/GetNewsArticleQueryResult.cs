using CapstoneProject_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.CQRS.Results.NewsArticleResults
{
    public class GetNewsArticleQueryResult
    {
        public int ArticleCategoryID { get; set; }
        public ArticleCategory ArticleCategory { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string WriterName { get; set; }
        public string ImageUrl { get; set; }
    }
}
