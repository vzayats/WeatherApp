using WeatherApp.Controllers;
using WeatherApp.Models;
using WeatherApp.Models.HistoryModels;

namespace WeatherApp.Services
{
    public class WeatherHistoryService
    {
        private readonly WeatherController _weatherController;

        public WeatherHistoryService(WeatherController weatherController)
        {
            _weatherController = weatherController;
        }

        public void SaveWeatherHistory(WeatherObject wForecast)
        {
            foreach (var item in wForecast.List)
            {
                _weatherController.Db.WeatherHistories.Add(new WeatherHistory
                {
                    CityHistoryId = item.Weather[0].Id,
                    WeatherIcon = item.Weather[0].Icon,
                    Date = item.Dt,
                    Description = item.Weather[0].Description,
                    MorningTemp = item.Temp.Morn,
                    DayTemp = item.Temp.Night,
                    EveningTemp = item.Temp.Eve,
                    NightTemp = item.Temp.Night,
                    Pressure = item.Pressure,
                    Humidity = item.Humidity,
                    Speed = item.Speed,
                    Rain = item.Rain
                });
                _weatherController.Db.CityHistories.Add(new CityHistory
                {
                    CityName = wForecast.City.Name,
                    Id = item.Weather[0].Id
                });
                _weatherController.Db.SaveChanges();
            }
        }
    }
}