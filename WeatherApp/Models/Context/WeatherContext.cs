using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WeatherApp.Models.Context
{
    public class WeatherContext : DbContext
    {
        public DbSet<SelectedCity> SelectedCities { get; set; }
    }
}