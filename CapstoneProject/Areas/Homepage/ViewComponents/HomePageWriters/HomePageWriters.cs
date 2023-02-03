using CapstoneProject_BusinessLayer.CQRS.Handlers.WriterHandlers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CapstoneProject.Areas.Homepage.ViewComponents.HomePageWriters
{
    public class HomePageWriters : ViewComponent
    {
        private readonly GetAllWritersInformationQueryHandler _getAllWritersInformationQueryHandler;

        public HomePageWriters(GetAllWritersInformationQueryHandler getAllWritersInformationQueryHandler)
        {
            _getAllWritersInformationQueryHandler = getAllWritersInformationQueryHandler;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = _getAllWritersInformationQueryHandler.Handle();
            return View(values);
        }
    }
}
