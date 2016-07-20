using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IWeatherHistoryService
    {
        void SaveWeatherHistory(WeatherObject wForecast);
    }
}