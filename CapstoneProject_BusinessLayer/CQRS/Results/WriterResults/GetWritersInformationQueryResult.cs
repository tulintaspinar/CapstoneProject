using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.CQRS.Results.WriterResults
{
    public class GetWritersInformationQueryResult
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Job { get; set; }
        public string ImageUrl { get; set; }
    }
}
