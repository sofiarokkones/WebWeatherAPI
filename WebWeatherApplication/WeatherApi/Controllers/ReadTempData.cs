using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Controllers
{
    public class ReadTempData
    {
        public async Task<List<WeatherForecast>> Read(string file)
        {
            return File.ReadAllLines(file)
                .Select(v => FromCsv(v))
                .ToList();
        }
        
        public static WeatherForecast FromCsv(string csvLine)
        {
            var values = csvLine.Split(';');
            var tempData = new WeatherForecast
            {
                TimeUnixEpoch = Convert.ToInt32(values[0]),
                TemperatureC = Convert.ToDecimal(values[1]),
                Date = Convert.ToDateTime(values[2])
            };
            
            return tempData;
        }
        
    }
}