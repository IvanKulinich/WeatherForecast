using System;

namespace WeatherForecast.Domain.Models.Views
{
    public class WeatherForecastViewModel
    {
        public DateTime Day { get; set; }

        public TemperatureViewModel Temperature { get; set; }

        public int Pressure { get; set; }

        public int Humidity { get; set; }
    }
}
