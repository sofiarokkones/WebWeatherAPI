using System.Collections.Generic;

namespace WeatherApi
{
    public class SMHIWeatherForecast
        {
            public List<TemperatureModelSMHI> value { get; set; }
            public ForecastSummary period { get; set; }
            
        }

        public class ForecastSummary
        {
            public string summary { get; set; }
            public long to { get; set; }
            public long from { get; set; }
        }
    

public class TemperatureModelSMHI
{
    public long date { get; set; }
    public string value { get; set; }
    public string quality { get; set; }

}

}
