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
    public class EfArticleCategoryDal : GenericRepository<ArticleCategory>, IArticleCategoryDal
    {
        public List<ArticleCategory> GetArticleCategoryByType()
        {
            using(var context = new Context())
            {
                return context.ArticleCategories.Include(x => x.TypesOfWriting).ToList();
            }
        }
    }
}
