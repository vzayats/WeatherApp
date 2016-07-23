using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Models.Context;
using WeatherApp.Models.HistoryModels;

namespace WeatherApp.Services
{
    public class WeatherHistoryService : IWeatherHistoryService
    {
        public async Task SaveWeatherHistoryAsync(WeatherObject wForecast)
        {
            if (wForecast != null)
                foreach (var item in wForecast.List)
                {
                    using (WeatherContext db = new WeatherContext())
                    {
                        db.WeatherHistories.Add(new WeatherHistory
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
                        db.CityHistories.Add(new CityHistory
                        {
                            CityName = wForecast.City.Name,
                            Id = item.Weather[0].Id
                        });
                        await db.SaveChangesAsync();
                    }
                }
        }
    }
}