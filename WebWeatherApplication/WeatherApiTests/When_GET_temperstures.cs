using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherApi;
using WeatherApi.Controllers;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using FluentAssertions;


namespace WeatherApiTests
{
    [TestClass]
    public class When_GET_temperatures
    {
        private readonly OkObjectResult _okObjectResult;
        private WeatherForecast _weatherForecastModel;
        private ReadTempData _reader;
        private ILogger<WeatherForecastController> _logger;
        private readonly IWeatherClient _client = A.Fake<IWeatherClient>();

        public When_GET_temperatures()
        {
            _weatherForecastModel = new WeatherForecast();
            _reader = new ReadTempData();
                
            //A.CallTo(() => _client.Get(A<string>._)).Returns(List<_weatherForecastModel>);
           
            var controller = new WeatherForecastController(_logger, _client);

            var result = controller.Get().GetAwaiter().GetResult();
            _okObjectResult = result as OkObjectResult;
        }
        
        [TestMethod]
        public void Should_send_request_once()
        {
            A.CallTo(() => _client.Get(A<string>._)).MustHaveHappenedOnceExactly();
        }
        
        [TestMethod]
        public void Should_return_correct_result()
        {
            _okObjectResult.Value.Should().BeOfType(typeof(List<WeatherForecast>));
        }
        
        [TestMethod]
        public void Should_return_correct_status_code()
        {
            _okObjectResult.StatusCode.Should().Be(200);
        }
    }
}