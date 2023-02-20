using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace API.Hubs
{
    public class MyHub : Hub
    {
        public static string Name { get; set; }
        public override async Task OnConnectedAsync()
        {
            string api = "9f9e9706e0ede9cd6b32befaee1ebceb";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            Name = document.Descendants("temperature").ElementAt(0).Attribute("value").Value.ToString();

            await Clients.All.SendAsync("ReceiveClientCount", Name);
        }
    }
}
