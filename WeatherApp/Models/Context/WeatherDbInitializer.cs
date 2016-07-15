using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WeatherApp.Models.Context
{
    public class WeatherDbInitializer : DropCreateDatabaseAlways<WeatherContext>
    {
        protected override void Seed(WeatherContext db)
        {
            db.SelectedCities.Add(new SelectedCity { Name = "Kiev" });
            db.SelectedCities.Add(new SelectedCity { Name = "Lviv" });
            db.SelectedCities.Add(new SelectedCity { Name = "Kharkiv" });
            db.SelectedCities.Add(new SelectedCity { Name = "Dnipropetrovsk" });
            db.SelectedCities.Add(new SelectedCity { Name = "Odessa" });

            base.Seed(db);
        }
    }
}