using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherApi
{
    public interface IWeatherClient
    {
        Task<List<WeatherForecast>> Get(string data);
    }
}