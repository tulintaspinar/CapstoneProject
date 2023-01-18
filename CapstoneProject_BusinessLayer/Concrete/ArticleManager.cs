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
    public class ArticleManager : IArticleService
    {
        IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public void TAdd(Article t)
        {
            _articleDal.Insert(t);
        }

        public void TDelete(Article t)
        {
            _articleDal.Delete(t);
        }

        public Article TGetById(int id)
        {
            return _articleDal.GetById(id);
        }

        public List<Article> TGetList()
        {
            return _articleDal.GetList();
        }
        public void TUpdate(Article t)
        {
            _articleDal.Update(t);
        }
    }
}
