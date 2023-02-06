using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using CapstoneProject.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Linq;
using System.Linq;

namespace CapstoneProject.Controllers
{
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            string api = "9f9e9706e0ede9cd6b32befaee1ebceb";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Trabzon&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.havaDurumu = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }

    }
}
