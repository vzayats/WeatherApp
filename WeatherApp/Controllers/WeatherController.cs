using System.Data.Entity;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.Mvc;
using WeatherApp.Models;
using WeatherApp.Models.Context;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        readonly IWeatherService _wService;
        readonly IWeatherHistoryService _hService;

        public WeatherController(IWeatherService weatherService, IWeatherHistoryService historyService)
        {
            _wService = weatherService;
            _hService = historyService;
        }

        private readonly WeatherContext _db = new WeatherContext();

        //GET: /Weather/Index
        [HttpGet]
        public async Task<ActionResult> Index(string city = "Kiev", int numberOfLines = 1, string daysNumber = "Сьогодні")
        {
            if (ModelState.IsValid && city != string.Empty)
            {
                var wForecast = _wService.GetWeatherForecast<WeatherObject>(city, numberOfLines);
                ViewBag.City = $"{wForecast.City.Name}, {wForecast.City.Country}";
                ViewBag.Weather = wForecast.List;
                ViewBag.Days = daysNumber;
                ViewBag.Cities = await _db.SelectedCities.ToListAsync();

                //Coordinates for Google Maps
                string coord =
                    $"{wForecast.City.Coord.Lat.ToString(CultureInfo.InvariantCulture)},{wForecast.City.Coord.Lon.ToString(CultureInfo.InvariantCulture)}";
                ViewBag.mapCoord = "https://www.google.com/maps/@" + coord + ",12.5z";

                if (wForecast.List != null)
                {
                    _hService.SaveWeatherHistory(wForecast);
                }
            }
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}