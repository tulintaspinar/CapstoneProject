using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.CQRS.Queries.WriterQueries
{
    public class GetWritersInformationQuery
    {
        public string UserName { get; set; }

        public GetWritersInformationQuery(string userName)
        {
            UserName = userName;
        }
    }
}
