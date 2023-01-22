using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-5CE3LGO;Database=UpSchoolCapstoneProjetc;Integrated Security=True;");
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<NewsArticle> NewsArticles { get; set; }
        public DbSet<TypesOfWriting> TypesOfWritings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserActivityTimeline> UserActivityTimelines { get; set; }
    }
}
