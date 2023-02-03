using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_DTOs.DTOs;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CapstoneProject.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly UserManager<AppUser> _userManager;

        public NotificationController(INotificationService notificationService, UserManager<AppUser> userManager)
        {
            _notificationService = notificationService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _notificationService.GetByUserId(user.Id);
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AddNotification()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNotification(NotificationAddDTO notificationAddDTO)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            _notificationService.TAdd(new Notification()
            {
                Title = notificationAddDTO.Title,
                Description = notificationAddDTO.Description,
                Status = "Not Read",
                Date = DateTime.Now,
                UserId = user.Id
            });
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult OpenNotification(int id)
        {
            var value = _notificationService.TGetById(id);

            return View(new NotificationEditDTO()
            {
                Title = value.Title,
                Description = value.Description,
                Id = value.NotificationId
            });
        }

        [HttpPost]
        public IActionResult OpenNotification(NotificationEditDTO notificationEditDTO)
        {
            var value = _notificationService.TGetById(notificationEditDTO.Id);
            value.Status = notificationEditDTO.Status;
            value.NotificationId = notificationEditDTO.Id;
            _notificationService.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}
