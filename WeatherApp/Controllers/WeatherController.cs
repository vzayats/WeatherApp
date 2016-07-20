using System.Linq;
using System.Web.Mvc;
using WeatherApp.Models;
using WeatherApp.Models.Context;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        readonly IWeatherService _wService;

        public WeatherController(IWeatherService weatherService)
        {
            _wService = weatherService;
            _weatherHistoryService = new WeatherHistoryService();
        }

        public readonly WeatherContext Db = new WeatherContext();
        private readonly WeatherHistoryService _weatherHistoryService;
        public string ApiRequest { get; private set; }

        //GET: /Weather/Index
        [HttpGet]
        public ActionResult Index(string city = "Kiev", int numberOfLines = 1, string daysNumber = "Сьогодні")
        {
            if (ModelState.IsValid && city != string.Empty)
            {
                var wForecast = _wService.GetWeatherForecast<WeatherObject>(city, numberOfLines);
                ViewBag.City = $"{wForecast.City.Name}, {wForecast.City.Country}";
                ViewBag.Weather = wForecast.List;
                ViewBag.Days = daysNumber;
                ViewBag.Cities = Db.SelectedCities.ToList();

                if (wForecast.List != null)
                {
                    _weatherHistoryService.SaveWeatherHistory(wForecast);
                    }
                }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            Db.Dispose();
            base.Dispose(disposing);
        }
    }
}