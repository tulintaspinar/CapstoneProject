using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_EntityLayer.Concrete
{
    public class UserActivityTimeline
    {
        public int UserActivityTimelineID { get; set; }
        public string WriterName { get; set; }
        public string TypeOfWritingName { get; set; }
        public DateTime Date { get; set; }
    }
}
