using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.BLL.Helpers;
using WeatherForecast.Domain.Interfaces;
using WeatherForecast.Domain.Models.Requests;
using WeatherForecast.Domain.Models.Views;
using WeatherForecast.Integrations.OneCallApi.Interfaces;

namespace WeatherForecast.BLL.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IOneCallApiService _oneCallApiService;

        public WeatherService(IOneCallApiService oneCallApiService)
        {
            _oneCallApiService = oneCallApiService;
        }

        public async Task<List<WeatherForecastViewModel>> GetForecastAsync(WeatherForecastRequestModel model)
        {
            var data = await _oneCallApiService.GetForecastDataAsync(model);

            return data.Daily
                .Select(x => new WeatherForecastViewModel
                {
                    Day = DateTimeHelper.ConvertUnixToDateTime(x.Dt),
                    Temperature = new TemperatureViewModel
                    {
                        Day = x.Temp.Day,
                        Min = x.Temp.Min,
                        Max = x.Temp.Max,
                        Morning = x.Temp.Morn,
                        Evening = x.Temp.Eve,
                        Night = x.Temp.Night
                    },
                    Pressure = x.Pressure,
                    Humidity = x.Humidity
                })
                .ToList();
        }
    }
}
