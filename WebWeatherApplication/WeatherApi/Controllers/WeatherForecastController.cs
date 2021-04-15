using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly string dataSource = @"/Users/sofia.rokkones/Projects/Code Is King/temperatures.csv";

        private readonly IWeatherClient _client;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherClient client)
        {
            _logger = logger;
            _client = client;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var data = await new ReadTempData().Read(dataSource);

            var data = await _client.Get(dataSource);
            return Ok(data.ToList());
        }
    }
}