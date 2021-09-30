using System.ComponentModel;

namespace WeatherForecast.Domain.Enums
{
    public enum TemperatureDegree
    {
        [Description("metric")]
        Celsius,
        [Description("imperial")]
        Fahrenheit
    }
}
