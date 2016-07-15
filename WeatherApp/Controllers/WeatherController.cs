using System;
using System.Linq;
using System.Web.Mvc;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        IWeatherService _wService;

        public WeatherController(IWeatherService weatherService)
        {
            _wService = weatherService;
        }

        public string ApiRequest { get; private set; }

        //GET: /Weather/Index
        [HttpGet]
        public ActionResult Index(string city = "Kiev", int numberOfLines = 1, string daysNumber = "Сьогодні")
        {
            if (ModelState.IsValid && city != string.Empty)
            {
                var wForecast = _wService.GetWeatherForecast<WeatherObject>(city, numberOfLines);
                ViewBag.City = String.Format("{0}, {1}", wForecast.City.Name, wForecast.City.Country);
                ViewBag.Weather = wForecast.List;
                ViewBag.Days = daysNumber;
            }
            
            return View();
        }
    }
}