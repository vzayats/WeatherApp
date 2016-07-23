using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApp.Services
{
    public class WeatherService : IWeatherService
    {
        public async Task<TEmperature> GetWeatherForecastAsync<TEmperature>(string city, int numberOfLines)
        {
            //Open Weather Map API key
            string apiId = System.Configuration.ConfigurationManager.AppSettings["APIKey"];
            //Open Weather Map API call
            string apiRequest =
                $"http://api.openweathermap.org/data/2.5/forecast/daily?q={city}&units=metric&APPID={apiId}&lang=ua&cnt={numberOfLines}";

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(apiRequest))
            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();
                return  await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<TEmperature>(result));
            }
        }
    }
}