using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IWeatherHistoryService
    {
        Task SaveWeatherHistoryAsync(WeatherObject wForecast);
    }
}