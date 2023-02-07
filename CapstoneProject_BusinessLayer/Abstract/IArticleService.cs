using CapstoneProject_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.Abstract
{
    public interface IArticleService : IGenericService<Article>
    {
        List<Article> GetArticleByCategory(string userName);
        List<Article> GetArticleByCategory();
        List<Article> GetByUserName(string userName);
    }
}
