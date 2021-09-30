using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecast.Domain.Models.Requests;
using WeatherForecast.Domain.Models.Views;

namespace WeatherForecast.Domain.Interfaces
{
    public interface IWeatherService
    {
        Task<List<WeatherForecastViewModel>> GetForecastAsync(WeatherForecastRequestModel model);
    }
}
