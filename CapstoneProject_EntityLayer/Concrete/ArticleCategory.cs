using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_EntityLayer.Concrete
{
    //Yazı türlerinin hangi kategori başlıkları altında yazı paylaşacağını belirtmek için
    public class ArticleCategory
    {
        public int ArticleCategoryID { get; set; }
        public string CategoryName { get; set; }

        //Hangi yazı türüne ait kategori olduğunu belirtmek için
        public int TypesOfWritingID { get; set; }
        public TypesOfWriting TypesOfWriting { get; set; }
    }
}
