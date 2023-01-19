using CapstoneProject_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.Abstract
{
    public interface INewsArticleService : IGenericService<NewsArticle>
    {
        List<NewsArticle> GetNewsArticleByCategory();
    }
}
