using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UWPWeatherService.Models;

namespace UWPWeatherService.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index(string lat, string lon)
        {
            double latitude = double.Parse(lat, CultureInfo.InvariantCulture);
            double longitude = double.Parse(lon, CultureInfo.InvariantCulture);

            var weather = await OpenWeatherMapProxy.GetWeather(latitude, longitude);
            ViewBag.Temp = weather.main.temp.ToString();
            ViewBag.Description = weather.weather[0].description;
            ViewBag.Name = weather.name;
            return View();
        }
    }
}