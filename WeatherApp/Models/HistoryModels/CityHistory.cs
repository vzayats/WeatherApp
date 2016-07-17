using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Models.HistoryModels
{
    public class CityHistory
    {
        [Key]
        public int CityId { get; set; }
        public int Id { get; set; }
        public string CityName { get; set; }
        public ICollection<WeatherHistory> WeatherHistories { get; set; }
        public CityHistory()
        {
            WeatherHistories = new List<WeatherHistory>();
        }
    }
}