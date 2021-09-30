using System;

namespace WeatherForecast.BLL.Helpers
{
    public class DateTimeHelper
    {
        public static DateTime ConvertUnixToDateTime(int unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimeStamp);
        }
    }
}
