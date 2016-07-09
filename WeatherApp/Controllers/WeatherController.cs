using System;
using System.Linq;
using System.Web.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private Services.WeatherService wService;

        //GET: /Weather/Index
        [HttpGet]
        public ActionResult Index(string city = "Kyiv", int take = 1, string daysNumber = "Сьогодні")
        {
            if (ModelState.IsValid && city != string.Empty)
            {
                //Open Weather Map API key
                string ApiId = System.Configuration.ConfigurationManager.AppSettings["APIKey"];
                //Open Weather Map API call
                string ApiRequest = String.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&units=metric&APPID={1}&lang=ua", city, ApiId);

                wService = new Services.WeatherService(ApiRequest);
                var wForecast = wService.GetWeatherForecast<WeatherObject>(city);
                ViewBag.City = String.Format("{0}, {1}", wForecast.City.Name, wForecast.City.Country);
                //Кількість днів для відображення
                ViewBag.Weather = wForecast.List.Take(take);
                ViewBag.Days = daysNumber;
            }
            
            return View();
        }
    }
}