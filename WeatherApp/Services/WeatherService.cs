using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace WeatherApp.Services
{
    public class WeatherService : IWeatherService
    {
        private string apiCall;

        public WeatherService(string apiCall)
        {
            this.apiCall = apiCall;
        }

        public Temperature GetWeatherForecast<Temperature>(string city)
        {
            //Open Weather Map API key
            string ApiId = System.Configuration.ConfigurationManager.AppSettings["APIKey"];
            //Open Weather Map API call
            string ApiRequest = String.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&units=metric&APPID={1}&lang=ua", city, ApiId);
            {
                var request = (HttpWebRequest)WebRequest.Create(ApiRequest);
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var reader = new StreamReader(response.GetResponseStream());
                    var responseText = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<Temperature>(responseText);
                }
            }
        }
    }
}