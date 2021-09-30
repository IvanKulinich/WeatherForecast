using System.Threading.Tasks;
using WeatherForecast.Domain.Models.Requests;
using WeatherForecast.Integrations.OneCallApi.Models;

namespace WeatherForecast.Integrations.OneCallApi.Interfaces
{
    public interface IOneCallApiService
    {
        Task<WeatherForecastResponse> GetForecastDataAsync(WeatherForecastRequestModel model);
    }
}
