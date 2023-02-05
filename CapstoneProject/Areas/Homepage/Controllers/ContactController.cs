using CapstoneProject.Areas.Homepage.Models;
using CapstoneProject_BusinessLayer.Abstract;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace CapstoneProject.Areas.Homepage.Controllers
{
    [Area("Homepage")]
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.model = _contactService.TGetContact();
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactViewModel contactViewModel)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", contactViewModel.Email);
            mimeMessage.From.Add(mailboxAddressFrom); //Mailin kimden gönderildiği

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", "mailgonderme3@gmail.com");
            mimeMessage.To.Add(mailboxAddressTo); //Mailin kime gönderileceği

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = contactViewModel.Message + " " +contactViewModel.PhoneNumber;
            mimeMessage.Body = bodyBuilder.ToMessageBody(); //Gönderilecek mailin içeriği

            mimeMessage.Subject = "Contact Me - "+contactViewModel.NameSurname; //Gönderilecek mailin başlığı

            SmtpClient smtp = new SmtpClient(); //SİMPLE MAİL TRANSFER PROTOCOL
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate("mailgonderme3@gmail.com", "ctzzbuomrtybukkl");
            smtp.Send(mimeMessage);
            smtp.Disconnect(true);
            return View();
        }
    }
}
