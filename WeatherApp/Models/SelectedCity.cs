using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
    public class SelectedCity
    {
        [Key]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Поле 'Назва' повинно бути заповненим!")]
        [System.ComponentModel.DisplayName("Назва")]
        public string Name { get; set; }
    }
}