using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_EntityLayer.Concrete
{
    //Haber Yazıları
    public class NewsArticle
    {
        public int NewsArticleID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string WriterName { get; set; }
        public string ImageUrl { get; set; }
        public int ArticleCategoryID { get; set; }
        public ArticleCategory ArticleCategory { get; set; }
    }
}
