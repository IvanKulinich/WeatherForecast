using WeatherForecast.Domain.Enums;

namespace WeatherForecast.Domain.Models.Requests
{
    public class WeatherForecastRequestModel
    {
        public double Lat { get; set; }

        public double Lon { get; set; }

        public TemperatureDegree TemperatureDegree { get; set; }

        public WeatherForecastRequestModel()
        {
            // Default values for Cyprus
            Lat = 35.1264;
            Lon = 33.4299;
        }
    }
}
