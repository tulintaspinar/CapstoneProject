﻿using CapstoneProject_DTOs.DTOs;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CapstoneProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUser signIn)
        {
            var result = await _signInManager.PasswordSignInAsync(signIn.UserName, signIn.PasswordHash, true, true);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }
    }
}
