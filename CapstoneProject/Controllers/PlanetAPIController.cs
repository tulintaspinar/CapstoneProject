using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using CapstoneProject.Models;
using System.Linq;

namespace CapstoneProject.Controllers
{
    public class PlanetAPIController : Controller
    {
        List<PlanetInfoViewList> planet = new List<PlanetInfoViewList>();
        public async Task<IActionResult> Index()
        {
            //Gezegenler hakkında bilgi
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://planets-info-by-newbapi.p.rapidapi.com/api/v1/planet/list"),
                Headers =
    {
        { "X-RapidAPI-Key", "12a214de2cmshc3823f8b62052c7p17b3e6jsnaf381c5f6f6d" },
        { "X-RapidAPI-Host", "planets-info-by-newbapi.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                planet = JsonConvert.DeserializeObject<List<PlanetInfoViewList>>(body);
            }
            return View(planet.OrderBy(x => x.planetOrder).ToList());
        }
    }
}
