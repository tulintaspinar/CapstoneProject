using CapstoneProject_DataAccessLayer.Abstract;
using CapstoneProject_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.Concrete
{
    public class ArticleManager : IArticleDal
    {
        IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public void Delete(Article t)
        {
            _articleDal.Delete(t);
        }

        public Article GetById(int id)
        {
            return _articleDal.GetById(id);
        }

        public List<Article> GetList()
        {
            return _articleDal.GetList();
        }

        public void Insert(Article t)
        {
            _articleDal.Insert(t);
        }

        public void Update(Article t)
        {
            _articleDal.Update(t);
        }
    }
}
