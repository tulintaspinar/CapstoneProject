using CapstoneProject_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_DataAccessLayer.Abstract
{
    public interface IUserActivityTimelineDal 
    {
        void Add(UserActivityTimeline userActivityTimeline);
        List<UserActivityTimeline> GetAllByUserName(string userName);
    }
}
