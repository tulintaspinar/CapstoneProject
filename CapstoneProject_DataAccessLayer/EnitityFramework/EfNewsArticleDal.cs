using CapstoneProject_DataAccessLayer.Abstract;
using CapstoneProject_DataAccessLayer.Concrete;
using CapstoneProject_DataAccessLayer.Repository;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_DataAccessLayer.EnitityFramework
{
    public class EfNewsArticleDal : GenericRepository<NewsArticle>, INewsArticleDal
    {
        public List<NewsArticle> GetByUserName(string userName)
        {
            using(var context = new Context())
            {
                return context.NewsArticles.Where(x => x.WriterName == userName).ToList();
            }
        }

        public List<NewsArticle> GetNewsArticleByCategory()
        {
            using(var context = new Context())
            {
                return context.NewsArticles.Include(x => x.ArticleCategory).ToList();
            }
        }

        public List<NewsArticle> GetNewsArticleByCategory(string userName)
        {
            using (var context = new Context())
            {
                return context.NewsArticles.Include(x => x.ArticleCategory).Where(x => x.WriterName == userName).ToList();
            }
        }
    }
}
