using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_DTOs.DTOs
{
    public class ArticleAddDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string WriterName { get; set; }
        public DateTime Date { get; set; }
        public IFormFile Image { get; set; }
        public string ImageUrl { get; set; }
        public string ArticleCategoryName { get; set; }
    }
}
