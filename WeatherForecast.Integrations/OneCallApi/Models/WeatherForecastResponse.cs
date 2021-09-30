using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherForecast.Integrations.OneCallApi.Models
{
    public class WeatherForecastResponse
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("timezone_offset")]
        public int TimezoneOffset { get; set; }

        [JsonProperty("daily")]
        public List<Daily> Daily { get; set; }
    }
}
