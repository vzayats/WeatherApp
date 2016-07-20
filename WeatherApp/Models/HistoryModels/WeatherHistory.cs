using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApp.Models.HistoryModels
{
    public class WeatherHistory
    {
        [Key, Column(Order = 1)]
        public int WeatherId { get; set; }
        public int Date { get; set; }
        public string Description { get; set; }
        public string WeatherIcon { get; set; }
        public double MorningTemp { get; set; }
        public double DayTemp { get; set; }
        public double NightTemp { get; set; }
        public double EveningTemp { get; set; }
        public double Pressure { get; set; }
        public int Humidity { get; set; }
        public double Speed { get; set; }
        public int Clouds { get; set; }
        public double Rain { get; set; }
        public int CityHistoryId { get; set; }
        public CityHistory CityHistory { get; set; }
    }
}