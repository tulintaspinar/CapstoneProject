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
    public class ArticleCategoryManager : IArticleCategoryService
    {
        IArticleCategoryDal _articleCategoryDal;

        public ArticleCategoryManager(IArticleCategoryDal articleCategoryDal)
        {
            _articleCategoryDal = articleCategoryDal;
        }

        public void TAdd(ArticleCategory t)
        {
            _articleCategoryDal.Insert(t);
        }

        public void TDelete(ArticleCategory t)
        {
            _articleCategoryDal.Delete(t);
        }

        public ArticleCategory TGetById(int id)
        {
            return _articleCategoryDal.GetById(id);
        }

        public List<ArticleCategory> TGetList()
        {
            return _articleCategoryDal.GetList();
        }

        public void TUpdate(ArticleCategory t)
        {
            _articleCategoryDal.Update(t);
        }
    }
}
