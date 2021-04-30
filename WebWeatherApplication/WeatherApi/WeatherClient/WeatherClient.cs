using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WeatherApi.Controllers;
using WeatherApi.TemperatureAnalyze;

namespace WeatherApi.WeatherClient
{
    public class WeatherClient :IWeatherClient
    {
        private HttpClient _httpClient = new();
        private WeatherForecast weatherForecast = new WeatherForecast();
        
        public async Task<List<WeatherForecast>> Get(string dataSource)
        {
            //var weatherData = await new ReadTempData().Read(dataSource);
            //return weatherData.ToList();

            var result = new SMHIWeatherForecast();
            var httpMessageResponse = await _httpClient.GetAsync(dataSource);
            if (httpMessageResponse.IsSuccessStatusCode)
            {
                result = await httpMessageResponse.Content.ReadFromJsonAsync<SMHIWeatherForecast>();
            }
            return weatherForecast.Map(result);
        }
        
        public async Task<WeatherForecast> GetWarmest(string dataSource)
        {
            //var weatherData = await new ReadTempData().Read(dataSource);
            //return TempAnalyzer.WarmestTemp(weatherData);
            
            var result = new SMHIWeatherForecast();
            var httpMessageResponse = await _httpClient.GetAsync(dataSource);
            if (httpMessageResponse.IsSuccessStatusCode)
            {
                result = await httpMessageResponse.Content.ReadFromJsonAsync<SMHIWeatherForecast>();
            }
            return TempAnalyzer.WarmestTemp(weatherForecast.Map(result));
        }
        
        public async Task<WeatherForecast> GetColdest(string dataSource)
        {
            //var weatherData = await new ReadTempData().Read(dataSource);
            //return TempAnalyzer.ColdestTemp(weatherData);
            var result = new SMHIWeatherForecast();
            var httpMessageResponse = await _httpClient.GetAsync(dataSource);
            if (httpMessageResponse.IsSuccessStatusCode)
            {
                result = await httpMessageResponse.Content.ReadFromJsonAsync<SMHIWeatherForecast>();
            }
            return TempAnalyzer.ColdestTemp(weatherForecast.Map(result));
        }
        
        public async Task<decimal> GetAverage(string dataSource)
        {
            //var weatherData = await new ReadTempData().Read(dataSource);
            //return TempAnalyzer.AverageTemp(weatherData);
            var result = new SMHIWeatherForecast();
            var httpMessageResponse = await _httpClient.GetAsync(dataSource);
            if (httpMessageResponse.IsSuccessStatusCode)
            {
                result = await httpMessageResponse.Content.ReadFromJsonAsync<SMHIWeatherForecast>();
            }
            return TempAnalyzer.AverageTemp(weatherForecast.Map(result));
        }
    }
}