using CapstoneProject_BusinessLayer.CQRS.Queries.WriterQueries;
using CapstoneProject_BusinessLayer.CQRS.Results.WriterResults;
using CapstoneProject_DataAccessLayer.Concrete;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.CQRS.Handlers.WriterHandlers
{
    public class GetWritersInformationQueryHandle
    {
        private readonly UserManager<AppUser> _userManager;

        public GetWritersInformationQueryHandle(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<GetWritersInformationQueryResult> Handle(GetWritersInformationQuery query)
        {
            var value = await _userManager.FindByNameAsync(query.UserName);
            return new GetWritersInformationQueryResult
            {
                Name = value.UserName,
                Surname = value.Surname,
                Job = value.Job,
                ImageUrl = value.Image
            };
        }
    }
}
