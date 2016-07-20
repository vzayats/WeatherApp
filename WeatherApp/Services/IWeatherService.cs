namespace WeatherApp.Services
{
    public interface IWeatherService
    {
        TEmperature GetWeatherForecast<TEmperature>(string city, int numberOfLines);
    }
}