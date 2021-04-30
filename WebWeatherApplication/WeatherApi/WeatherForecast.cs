using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace WeatherApi
{
    public class WeatherForecast : IWeatherForecast
    {
        public long TimeUnixEpoch { get; set; }
        public DateTime Date { get; set; }
        public decimal TemperatureC { get; set; }
        
        public List<WeatherForecast> Map(SMHIWeatherForecast data)
        {
            var result = new List<WeatherForecast>();
            foreach (var tempdata in data.value)
            {
                DateTimeOffset dateTimeOffSet = DateTimeOffset.FromUnixTimeMilliseconds(tempdata.date);
                DateTime dateTime = dateTimeOffSet.DateTime;
                
                result.Add(new WeatherForecast
                {
                    TemperatureC = decimal.Parse(tempdata.value),
                    TimeUnixEpoch = tempdata.date,
                    Date = dateTime
                });
            }
            return result;
        }
    }
}