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
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public List<Notification> GetByUserId(int id)
        {
            using(var context = new Context())
            {
                return context.Notifications.Where(x => x.UserId == id).ToList();
            }
        }
    }
}
