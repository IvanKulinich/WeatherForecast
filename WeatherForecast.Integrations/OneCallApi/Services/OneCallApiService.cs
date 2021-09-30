using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherForecast.Domain.Extensions;
using WeatherForecast.Domain.Models.Requests;
using WeatherForecast.Integrations.OneCallApi.Interfaces;
using WeatherForecast.Integrations.OneCallApi.Models;

namespace WeatherForecast.Integrations.OneCallApi.Services
{
    public class OneCallApiService : IOneCallApiService
    {
        private static readonly HttpClient client;

        static OneCallApiService()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri(Environment.GetEnvironmentVariable("ONE_CALL_API_BASE_URL"))
            };
        }

        public async Task<WeatherForecastResponse> GetForecastDataAsync(WeatherForecastRequestModel model)
        {
            string apiKey = Environment.GetEnvironmentVariable("ONE_CALL_API_KEY");

            var url = string.Format(
                "/data/2.5/onecall?lat={0}&lon={1}&units={2}&exclude=current,minutely,hourly,alerts&appid={3}",
                model.Lat,
                model.Lon,
                model.TemperatureDegree.ToDescriptionString(),
                apiKey);

            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            var stringResponse = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<WeatherForecastResponse>(stringResponse, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }
    }
}
