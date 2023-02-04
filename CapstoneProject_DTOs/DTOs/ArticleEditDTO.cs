using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_DTOs.DTOs
{
    public class ArticleEditDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; }
        //public int ArticleCategoryID { get; set; }
        //public ArticleCategory ArticleCategory { get; set; }
    }
}
