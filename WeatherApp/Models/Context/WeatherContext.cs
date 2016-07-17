using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WeatherApp.Models.HistoryModels;

namespace WeatherApp.Models.Context
{
    public class WeatherContext : DbContext
    {
        public DbSet<SelectedCity> SelectedCities { get; set; }
        public DbSet<WeatherHistory> WeatherHistories { get; set; }
        public DbSet<CityHistory> CityHistories { get; set; }
    }
}