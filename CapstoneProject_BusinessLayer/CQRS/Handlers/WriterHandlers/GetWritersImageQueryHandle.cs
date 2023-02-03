using CapstoneProject_BusinessLayer.CQRS.Results.WriterResults;
using CapstoneProject_DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.CQRS.Handlers.WriterHandlers
{
    public class GetWritersImageQueryHandle
    {
        private readonly Context _context;

        public GetWritersImageQueryHandle(Context context)
        {
            _context = context;
        }
        public List<Results.WriterResults.GetWritersImageQueryResult> Handle()
        {
            var values = _context.Users.Select(x=>new GetWritersImageQueryResult
            {
                ImageUrl=x.Image
            }).ToList();
            return values;
        }
    }
}
