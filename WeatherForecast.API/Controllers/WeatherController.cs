using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecast.Domain.Interfaces;
using WeatherForecast.Domain.Models.Requests;
using WeatherForecast.Domain.Models.Views;

namespace WeatherForecast.API.Controllers
{
    [Route("api/weather")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("forecast")]
        [ProducesResponseType(typeof(List<WeatherForecastViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetForecastAsync([FromQuery] WeatherForecastRequestModel model)
        {
            try
            {
                var result = await _weatherService.GetForecastAsync(model);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
