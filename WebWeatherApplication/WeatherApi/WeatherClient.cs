using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApi.Controllers;

namespace WeatherApi
{
    public class WeatherClient :IWeatherClient
    {
        public async Task<List<WeatherForecast>> Get(string dataSource)
        {
            var weatherData = await new ReadTempData().Read(dataSource);
            return weatherData;
        }
    }
}