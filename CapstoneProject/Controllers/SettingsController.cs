using CapstoneProject_DTOs.DTOs;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Threading.Tasks;
using CapstoneProject_BusinessLayer.Abstract;
using System.Linq;
using System.Collections.Generic;
using CapstoneProject_BusinessLayer.ValidationRules;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CapstoneProject.Controllers
{
    public class SettingsController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly UserManager<AppUser> _userManager;
        private readonly INewsArticleService _newsArticleService;
        private readonly IUserActivityTimelineService _userActivityTimelineService;
        public SettingsController(UserManager<AppUser> userManager, IArticleService articleService, INewsArticleService newsArticleService, IUserActivityTimelineService userActivityTimelineService)
        {
            _userManager = userManager;
            _articleService = articleService;
            _newsArticleService = newsArticleService;
            _userActivityTimelineService = userActivityTimelineService;
        }

        [HttpGet]
        public async Task<IActionResult> Account()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserImage = user.Image;
            ViewBag.UserName = user.Name + " " + user.Surname;
            ViewBag.Job = user.Job;
            ViewBag.JoinDate = user.JoinDate.ToShortDateString();

            var articles = _articleService.GetByUserName(user.UserName);
            var newsArticles = _newsArticleService.GetByUserName(user.UserName);

            ViewBag.ArticleCount = articles.Count;
            ViewBag.NewsArticleCount = newsArticles.Count;
            ViewBag.TotalCount = articles.Count + newsArticles.Count;

            ViewBag.ActivityTimeline = _userActivityTimelineService.GetAllByUserName(user.UserName).OrderByDescending(x => x.Date).TakeLast(5);
            ViewBag.TotalEmployeeCount = _userManager.Users.Count();

            return View(new UserDTO()
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                UserName = user.UserName,
                Phone = user.PhoneNumber,
                Age = user.Age,
                Job = user.Job
            });
        }
        
        [HttpGet]
        public async Task<IActionResult> Setting()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserImage = user.Image;
            return View(new UserEditDTO() { Name = user.Name, Surname = user.Surname, Email = user.Email, Phone = user.PhoneNumber, UserName = user.UserName, Job=user.Job,Age=user.Age });
        }
        [HttpPost]
        public async Task<IActionResult> Setting(UserEditDTO userEditDTO)
        {
            SettingEditValidator rules = new SettingEditValidator();
            ValidationResult result = rules.Validate(userEditDTO);

            if (result.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = userEditDTO.Name;
                user.Surname = userEditDTO.Surname;
                user.Age = userEditDTO.Age;
                user.Email = userEditDTO.Email;
                user.PhoneNumber = userEditDTO.Phone;
                user.UserName = userEditDTO.UserName;
                user.Job = userEditDTO.Job;
                
                if(userEditDTO.ImageUrl!= null)
                {
                    user.Image = userEditDTO.ImageUrl;
                }
                if (userEditDTO.Password != null)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditDTO.Password);
                }
                var success = await _userManager.UpdateAsync(user);
                if (success.Succeeded)
                {
                    return RedirectToAction("Account");
                }
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

        [HttpPost]
        public async Task<IActionResult> UploadPhoto(UserEditDTO userEditDTO)
        {
            if (userEditDTO.Image != null)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                var extension = Path.GetExtension(userEditDTO.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/IMAGES/UserImages/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                userEditDTO.Image.CopyTo(stream);

                user.Image = newImageName;

                var success = await _userManager.UpdateAsync(user);
                if (success.Succeeded)
                {
                    return RedirectToAction("Account");
                }
            }
            return RedirectToAction("Setting");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAccount(string accountActivation)
        {
            if (accountActivation != null)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Login");
                }
            }
            return RedirectToAction("Setting");
        }
    }
}
