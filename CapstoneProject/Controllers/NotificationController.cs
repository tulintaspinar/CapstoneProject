using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_BusinessLayer.ValidationRules;
using CapstoneProject_DTOs.DTOs;
using CapstoneProject_EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
            var values = _notificationService.TGetList().Where(x=>x.UserId!=user.Id).ToList();
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
            NotificationAddValidator validations  =new NotificationAddValidator();
            ValidationResult result = validations.Validate(notificationAddDTO);
            if (result.IsValid)
            {
                var user = await _userManager.FindByIdAsync(notificationAddDTO.UserId);
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
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
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
