using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_BusinessLayer.Concrete;
using CapstoneProject_DataAccessLayer.Abstract;
using CapstoneProject_DataAccessLayer.EnitityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneProject_BusinessLayer.CQRS.Handlers.WriterHandlers;
using CapstoneProject_BusinessLayer.CQRS.Handlers.ArticleHandlers;
using CapstoneProject_BusinessLayer.CQRS.Handlers.NewsArticleHandlers;
using CapstoneProject_BusinessLayer.CQRS.Handlers.ArticlecategoriesHandlers;

namespace CapstoneProject_BusinessLayer.DIContainer
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITypesOfWritingService, TypesOfWritingManager>();
            services.AddScoped<ITypesOfWritingDal, EfTypesOfWritingDal>();

            services.AddScoped<IArticleCategoryService, ArticleCategoryManager>();
            services.AddScoped<IArticleCategoryDal, EfArticleCategoryDal>();

            services.AddScoped<IArticleService, ArticleManager>();
            services.AddScoped<IArticleDal, EfArticleDal>();

            services.AddScoped<INewsArticleService, NewsArticleManager>();
            services.AddScoped<INewsArticleDal, EfNewsArticleDal>();

            services.AddScoped<INotificationDal, EfNotificationDal>();
            services.AddScoped<INotificationService, NotificationManager>();

            services.AddScoped<IUserActivityTimelineDal, EfUserActivityTimelineDal>();
            services.AddScoped<IUserActivityTimelineService,UserActivityTimelineManager>();

            //CQRS
            services.AddScoped<GetLastThreeArticleQueryHandler>();
            services.AddScoped<GetTwoArticleQueryHandler>();
            services.AddScoped<GetFiveArticleCategoriesQueryHandler>();
            services.AddScoped<GetThreeNewsArticleCategoriesQueryHandler>();
            services.AddScoped<GetNewsArticleQueryHandler>();
            services.AddScoped<GetFiveNewsArticleQueryHandler>();
            services.AddScoped<GetWritersImageQueryHandle>();
            services.AddScoped<GetWritersInformationQueryHandle>();
        }
    }

}
