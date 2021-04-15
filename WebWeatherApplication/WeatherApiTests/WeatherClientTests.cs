using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherApi;

namespace WeatherApiTests
{
    [TestClass]
    public class WeatherClientTests
    {
        private readonly WeatherClient _client;
        private readonly string dataSource = @"/Users/sofia.rokkones/Projects/Code Is King/temperatures.csv";

        public WeatherClientTests()
        {
            _client = new WeatherClient();
        }
        
        [TestMethod]
        public async Task Should_be_able_to_get_weather_data_from_file()
        {
            var data = _client.Get(dataSource);
            data.Result.Should().BeOfType(typeof(List<WeatherForecast>));
            data.Result.Should().NotBeEmpty();
        }
    }
}