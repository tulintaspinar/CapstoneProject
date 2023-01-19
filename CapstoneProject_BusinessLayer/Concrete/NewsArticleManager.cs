using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_DataAccessLayer.Abstract;
using CapstoneProject_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.Concrete
{
    public class NewsArticleManager : INewsArticleService
    {
        INewsArticleDal _newsArticleDal;

        public NewsArticleManager(INewsArticleDal newsArticleDal)
        {
            _newsArticleDal = newsArticleDal;
        }

        public List<NewsArticle> GetNewsArticleByCategory()
        {
            return _newsArticleDal.GetNewsArticleByCategory();
        }

        public void TAdd(NewsArticle t)
        {
            _newsArticleDal.Insert(t);
        }

        public void TDelete(NewsArticle t)
        {
            _newsArticleDal.Delete(t);
        }

        public NewsArticle TGetById(int id)
        {
            return _newsArticleDal.GetById(id);
        }

        public List<NewsArticle> TGetList()
        {
            return _newsArticleDal.GetList();
        }

        public void TUpdate(NewsArticle t)
        {
            _newsArticleDal.Update(t);
        }
    }
}
