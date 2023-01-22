using CapstoneProject_DataAccessLayer.Abstract;
using CapstoneProject_DataAccessLayer.Concrete;
using CapstoneProject_DataAccessLayer.Repository;
using CapstoneProject_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_DataAccessLayer.EnitityFramework
{
    public class EfUserActivityTimelineDal : IUserActivityTimelineDal
    {
        public void Add(UserActivityTimeline userActivityTimeline)
        {
            using(var context = new Context())
            {
                context.UserActivityTimelines.Add(userActivityTimeline);
                context.SaveChanges();
            }
        }

        public List<UserActivityTimeline> GetAllByUserName(string userName)
        {
            using(var context = new Context())
            {
                return context.UserActivityTimelines.Where(x => x.WriterName == userName).ToList();
            }
        }
    }
}
