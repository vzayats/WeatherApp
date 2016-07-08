using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace WeatherApp.Services
{
    public class WeatherService
    {
        private string apiCall;
        private string apiId;
        private string v;

        public WeatherService(string apiCall)
        {
            this.apiCall = apiCall;
        }

        public WeatherService(string v, string apiId)
        {
            this.v = v;
            this.apiId = apiId;
        }

        public Temperature GetWeatherForecast<Temperature>(string city)
        {
            {
                var request = (HttpWebRequest)WebRequest.Create(apiCall);
                var response = (HttpWebResponse)request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream());
                var responseText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<Temperature>(responseText);
            }
        }
    }
}