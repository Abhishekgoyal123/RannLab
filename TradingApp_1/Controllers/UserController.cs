using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TradingApp_1.Models;

namespace TradingApp_1.Controllers
{

    public class UserController : Controller
    {
        HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> getAddInfo()
        {
            
            var ads = await client.GetFromJsonAsync<List<AdsInfo>>("https://localhost:7117/api/FetchAds");
            //var a =JsonSerializer.Deserialize<List<AdsInfo>>(ads);
            return View(ads);
        }
    }
}
