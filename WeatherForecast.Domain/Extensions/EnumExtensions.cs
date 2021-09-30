using System.ComponentModel;
using WeatherForecast.Domain.Enums;

namespace WeatherForecast.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDescriptionString(this TemperatureDegree temperatureDegree)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])temperatureDegree
               .GetType()
               .GetField(temperatureDegree.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
