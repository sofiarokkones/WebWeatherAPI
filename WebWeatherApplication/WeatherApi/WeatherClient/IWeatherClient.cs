using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherApi.WeatherClient
{
    public interface IWeatherClient
    {
        Task<List<WeatherForecast>> Get(string data);
        Task<WeatherForecast> GetWarmest(string dataSource);
        Task<WeatherForecast> GetColdest(string dataSource);
        Task<decimal> GetAverage(string dataSource);
    }
}