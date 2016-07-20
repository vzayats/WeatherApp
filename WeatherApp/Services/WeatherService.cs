using Newtonsoft.Json;
using System.Net.Http;

namespace WeatherApp.Services
{
    public class WeatherService : IWeatherService
    {
        public Temperature GetWeatherForecast<Temperature>(string city, int numberOfLines)
        {
            //Open Weather Map API key
            string apiId = System.Configuration.ConfigurationManager.AppSettings["APIKey"];
            //Open Weather Map API call
            string apiRequest =
                $"http://api.openweathermap.org/data/2.5/forecast/daily?q={city}&units=metric&APPID={apiId}&lang=ua&cnt={numberOfLines}";

            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = client.GetAsync(apiRequest).Result)
            using (HttpContent content = response.Content)
            {
                string result = content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Temperature>(result);
            }
        }
    }
}