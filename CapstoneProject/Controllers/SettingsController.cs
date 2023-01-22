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

            ViewBag.ActivityTimeline = _userActivityTimelineService.GetAllByUserName(user.UserName).OrderByDescending(x=>x.Date);

            
            return View(new UserDTO() 
            { 
                Name=user.Name,Surname=user.Surname,Email=user.Email,UserName=user.UserName,Phone=user.PhoneNumber,Age=user.Age,Job=user.Job
            });
        }
        [HttpGet]
        public async Task<IActionResult> Setting()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserImage = user.Image;
            return View(new UserEditDTO() { Name=user.Name,Surname=user.Surname,Email=user.Email,Phone=user.PhoneNumber,UserName=user.UserName});
        }
        [HttpPost]
        public async Task<IActionResult> Setting(UserEditDTO userEditDTO)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name = userEditDTO.Name;
            user.Surname = userEditDTO.Surname;
            user.Age = userEditDTO.Age;
            user.Email = userEditDTO.Email;
            user.PhoneNumber = userEditDTO.Phone;
            user.UserName = userEditDTO.UserName;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditDTO.Password);

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Account");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadPhoto(UserEditDTO userEditDTO)
        {
            if (ModelState.IsValid)
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

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Account");
                    }
                    else
                    {
                        return RedirectToAction("Setting");
                    }
                }
                else
                {
                    return RedirectToAction("Setting");
                }
            }
            else
            {
                return RedirectToAction("Setting");
            }

        }

        [HttpPost]
        public async Task<IActionResult> DeleteAccount(string lblcheck)
        {
            if (lblcheck != null)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var result = await _userManager.DeleteAsync(new AppUser() { Id = user.Id });
                if (result.Succeeded)
                {
                    return RedirectToAction("Account");
                }
            }
            return RedirectToAction("Setting");
        }
    }
}
