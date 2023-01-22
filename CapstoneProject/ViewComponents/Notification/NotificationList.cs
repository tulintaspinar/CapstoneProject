using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.ViewComponents.Notification
{
    public class NotificationList : ViewComponent
    {
        private readonly INotificationService _notificationService;
        private readonly UserManager<AppUser> _userManager;

        public NotificationList(INotificationService notificationService, UserManager<AppUser> userManager)
        {
            _notificationService = notificationService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _notificationService.GetByUserId(user.Id).TakeLast(3).ToList();
            return View(values);
        }
    }
}
