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
    public class EfArticleDal : GenericRepository<Article>, IArticleDal
    {
        public List<Article> GetArticleByCategory(string userName)
        {
            using(var context = new Context())
            {
                return context.Articles.Include(x=>x.ArticleCategory).Where(x=>x.WriterName==userName).ToList();
            }
        }

        public List<Article> GetArticleByCategory()
        {
            using(var context=new Context())
            {
                return context.Articles.Include(x => x.ArticleCategory).ToList();
            }
        }
        public List<Article> GetByUserName(string userName)
        {
            using (var context = new Context())
            {
                return context.Articles.Where(x => x.WriterName == userName).ToList();
            }
        }
    }
}
