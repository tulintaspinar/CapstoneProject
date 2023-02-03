using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_DTOs.DTOs;
using CapstoneProject_EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace CapstoneProject.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserActivityTimelineService _userActivityTimelineService;

        public RegisterController(UserManager<AppUser> userManager, IUserActivityTimelineService userActivityTimelineService)
        {
            _userManager = userManager;
            _userActivityTimelineService = userActivityTimelineService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterDTO register)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    Name = register.Name,
                    Surname = register.Surname,
                    Email = register.Email,
                    Age=register.Age,
                    UserName = register.UserName,
                    NormalizedUserName = register.UserName.ToUpper(),
                    JoinDate = DateTime.Now,
                    Job=register.Job,
                    EmailConfirmedCode = new Random().Next(100000, 999999).ToString()
                };
                var result = await _userManager.CreateAsync(appUser, register.Password);
                if(result.Succeeded)
                {
                    _userActivityTimelineService.Add(new UserActivityTimeline()
                    {
                        WriterName= register.UserName,
                        TypeOfWritingName ="Register",
                        Date=DateTime.Now
                    });

                    SendEmail(appUser.EmailConfirmedCode,register.Email);

                    return RedirectToAction("EmailConfirm");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult EmailConfirm()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EmailConfirm(AppUser appUser)
        {
            var user = await _userManager.FindByEmailAsync(appUser.Email);
            if (user.EmailConfirmedCode == appUser.EmailConfirmedCode)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPasswordCode()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> ForgotPasswordCode(AppUser appUser)
        {
            if (appUser.Email != null)
            {
                var emailCode = new Random().Next(100000, 999999).ToString();
                SendEmail(emailCode, appUser.Email);

                var user = await _userManager.FindByEmailAsync(appUser.Email);
                user.ForgotPasswordCode= emailCode;
                await _userManager.UpdateAsync(user);

                return RedirectToAction("ForgotPassword");
            }
            return View();
        }
        
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordDTO.Email);
            if (forgotPasswordDTO.ForgotPasswordCode == user.ForgotPasswordCode)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, forgotPasswordDTO.Password);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index","Login");
            }
            return View();
        }
        public void SendEmail(string emailcode,string email)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "mailgonderme3@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom); //Mailin kimden gönderildiği

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", email);
            mimeMessage.To.Add(mailboxAddressTo); //Mailin kime gönderileceği

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = emailcode;
            mimeMessage.Body = bodyBuilder.ToMessageBody(); //Gönderilecek mailin içeriği

            mimeMessage.Subject = "Üyelik Kaydı"; //Gönderilecek mailin başlığı

            SmtpClient smtp = new SmtpClient(); //SİMPLE MAİL TRANSFER PROTOCOL
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate("mailgonderme3@gmail.com", "fwoqmvrksyrjspxv");
            smtp.Send(mimeMessage);
            smtp.Disconnect(true);
        }
    }
}
