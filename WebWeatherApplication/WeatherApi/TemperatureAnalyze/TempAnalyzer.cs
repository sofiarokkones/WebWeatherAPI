using System.Collections.Generic;
using System.Linq;

namespace WeatherApi.TemperatureAnalyze
{
    public class TempAnalyzer
    { 
        public static WeatherForecast ColdestTemp(List<WeatherForecast> data)
        {
            return data.OrderBy(item => item.TemperatureC).FirstOrDefault();
        }
        public static WeatherForecast WarmestTemp(List<WeatherForecast> data)
        {
            return data.OrderByDescending(item => item.TemperatureC).FirstOrDefault();
        }
        public static decimal AverageTemp(List<WeatherForecast> data)
        {
            return decimal.Round(data.Sum(t => t.TemperatureC) / data.Count, 1);
        }
    }
}