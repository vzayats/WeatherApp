using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApp.Models.HistoryModels
{
    public class CityHistory
    {
        [Key, Column(Order = 1)]
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