using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_DataAccessLayer.Abstract;
using CapstoneProject_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.Concrete
{
    public class UserActivityTimelineManager : IUserActivityTimelineService
    {
        private readonly IUserActivityTimelineDal _userActivityTimelineDal;

        public UserActivityTimelineManager(IUserActivityTimelineDal userActivityTimelineDal)
        {
            _userActivityTimelineDal = userActivityTimelineDal;
        }

        public void Add(UserActivityTimeline userActivityTimeline)
        {
            _userActivityTimelineDal.Add(userActivityTimeline);
        }

        public List<UserActivityTimeline> GetAllByUserName(string userName)
        {
            return _userActivityTimelineDal.GetAllByUserName(userName);
        }
    }
}
