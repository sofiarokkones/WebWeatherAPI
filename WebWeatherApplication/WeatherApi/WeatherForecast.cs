using System;

namespace WeatherApi
{
    public class WeatherForecast
    {
        public int TimeUnixEpoch { get; set; }
        public DateTime Date { get; set; }

        public decimal TemperatureC { get; set; }

        public int TemperatureF => 32 + (int) (TemperatureC / (decimal) 0.5556);

        public string Summary { get; set; }
        
        
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