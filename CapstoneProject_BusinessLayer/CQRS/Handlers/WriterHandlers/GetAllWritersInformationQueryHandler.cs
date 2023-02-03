using CapstoneProject_BusinessLayer.CQRS.Results.WriterResults;
using CapstoneProject_DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.CQRS.Handlers.WriterHandlers
{
    public class GetAllWritersInformationQueryHandler
    {
        private readonly Context _context;

        public GetAllWritersInformationQueryHandler(Context context)
        {
            _context = context;
        }
        public List<GetAllWritersInformationQueryResult> Handle()
        {
            var values = _context.Users.Select(x=>new GetAllWritersInformationQueryResult
            {
                ImageUrl=x.Image
            }).ToList();
            return values;
        }
    }
}
