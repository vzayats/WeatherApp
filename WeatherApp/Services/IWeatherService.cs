using System.Threading.Tasks;

namespace WeatherApp.Services
{
    public interface IWeatherService
    {
        Task<TEmperature> GetWeatherForecastAsync<TEmperature>(string city, int numberOfLines);
    }
}