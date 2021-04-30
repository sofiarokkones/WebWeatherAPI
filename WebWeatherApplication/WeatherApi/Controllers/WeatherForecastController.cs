using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherApi.WeatherClient;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
        //private readonly string dataSource = @"/Users/sofia.rokkones/Projects/Code Is King/temperatures.csv";
        private readonly string _dataSource = $"https://opendata-download-metobs.smhi.se/api/version/latest/parameter/1/station/" + "98230" + "/period/latest-months/data.json"; // Sthlm = 98230

        private readonly IWeatherClient _client;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherClient client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpGet("/alltemps")]
        public async Task<IActionResult> Get()
        {
            var data = await _client.Get(_dataSource);
            return Ok(data);
        }
        
        [HttpGet("/warmestday")]
        public async Task<IActionResult> GetWarmest()
        {
            var data = await _client.GetWarmest(_dataSource);
            return Ok(data);
        }
        
        [HttpGet("/coldestday")]
        public async Task<IActionResult> GetColdest()
        {
            var data = await _client.GetColdest(_dataSource);
            return Ok(data);
        }
        
        [HttpGet("/average")]
        public async Task<IActionResult> GetAverage()
        {
            var data = await _client.GetAverage(_dataSource);
            return Ok(data);
        }
        
    }
}