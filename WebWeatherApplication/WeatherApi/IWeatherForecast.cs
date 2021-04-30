using System.Collections.Generic;

namespace WeatherApi
{
    public interface IWeatherForecast
    {
        List<WeatherForecast> Map(SMHIWeatherForecast data);
    }
}