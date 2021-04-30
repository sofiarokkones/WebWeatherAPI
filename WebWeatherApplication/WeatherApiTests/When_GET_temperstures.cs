using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherApi;
using WeatherApi.Controllers;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using FluentAssertions;
using WeatherApi.WeatherClient;


namespace WeatherApiTests
{
    [TestClass]
    public class When_GET_temperatures
    {
        private readonly OkObjectResult _okObjectResult;
        private ILogger<WeatherForecastController> _logger;
        private readonly IWeatherClient _client = A.Fake<IWeatherClient>();
        private List<WeatherForecast> _viewModel;
        private readonly IWeatherForecast _weatherForecast = A.Fake<IWeatherForecast>();

        public When_GET_temperatures()
        {
            _viewModel = new List<WeatherForecast>();
            A.CallTo(() => _client.Get(A<string>._)).Returns(_viewModel);
            
            A.CallTo(() => _weatherForecast.Map(A<SMHIWeatherForecast>._)).Returns(_viewModel);

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
        
        // [TestMethod]
        // public void Should_map_to_view_model_once()
        // {
        //     A.CallTo(() => _weatherForecast.Map(A<SMHIWeatherForecast>._)).MustHaveHappenedOnceExactly();
        // }
        //
        // [TestMethod]
        // public void Should_return_correct_view_model()
        // {
        //     var tempViewModel = (List<WeatherForecast>)_okObjectResult.Value;
        //     tempViewModel.First().Should().BeOfType(_viewModel);
        // }
        
        [TestMethod]
        public void Should_return_correct_status_code()
        {
            _okObjectResult.StatusCode.Should().Be(200);
        }
    }
}