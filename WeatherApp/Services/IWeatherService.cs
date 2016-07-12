namespace WeatherApp.Services
{
    public interface IWeatherService
    {
        Temperature GetWeatherForecast<Temperature>(string city, int numberOfLines);
    }
}