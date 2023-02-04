using AutoMapper;
using CapstoneProject_DTOs.DTOs;
using CapstoneProject_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_DTOs.Mapping.AutoMapperFile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ArticleAddDTO, Article>().ReverseMap();
            CreateMap<ArticleEditDTO, Article>().ReverseMap();

            CreateMap<ArticleCategoryAddDTO, ArticleCategory>().ReverseMap();
            CreateMap<ArticleCategoryEditDTO, ArticleCategory>().ReverseMap();
        
            CreateMap<NewsArticleAddDTO, NewsArticle>().ReverseMap();   
            CreateMap<NewsArticleEditDTO, NewsArticle>().ReverseMap();
            
            CreateMap<NotificationAddDTO,Notification>().ReverseMap();
            CreateMap<NotificationEditDTO,Notification>().ReverseMap();

            CreateMap<RegisterDTO,AppUser>().ReverseMap();

            CreateMap<RoleAddDTO,AppRole>().ReverseMap();
            CreateMap<RoleAssignDTO,AppRole>().ReverseMap();
            CreateMap<RoleEditDTO,AppRole>().ReverseMap();

            CreateMap<TypesOfWritingAddDTO,TypesOfWriting>().ReverseMap();

            CreateMap<UserDTO,AppUser>().ReverseMap();
            CreateMap<UserEditDTO,AppUser>().ReverseMap();
        
        
        }
    }
}
