using CapstoneProject_EntityLayer.Concrete;
using System;

namespace CapstoneProject_BusinessLayer.CQRS.Results.ArticleResults
{
    public class GetArticleQueryResult
    {
        //Banner - More Posts
        public int ArticleCategoryID { get; set; }
        public ArticleCategory ArticleCategory { get; set; }    
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string WriterName { get; set; }
        public string ImageUrl { get; set; }
        public string WriterImageUrl { get; set; }
    }
}
