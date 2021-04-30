using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WeatherMVC.Models;

namespace WeatherMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _client;

        public HomeController(ILogger<HomeController> logger, HttpClient client)
        {
            _logger = logger;
            _client = client;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }


        public async Task<IActionResult> Data()
        {
            List<DataModel> dataPoints = new List<DataModel>();

            _client.BaseAddress = new Uri("http://localhost:5000/");
            var httpResponseMessage = await _client.GetAsync("alltemps");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var readTask = httpResponseMessage.Content.ReadAsStringAsync();
                readTask.Wait();
                var response = JsonConvert.DeserializeObject<List<WeatherViewModel>>(readTask.Result);

                dataPoints.AddRange(response.Select(d => new DataModel(d.timeUnixEpoch, d.temperatureC)));

                ViewBag.DataModels = JsonConvert.SerializeObject(dataPoints);
            }

            return View();
        }

        public async Task<IActionResult> Weather()
        {
            var weatherList = new List<WeatherViewModel>();

            _client.BaseAddress = new Uri("http://localhost:5000/");
            var httpResponseMessage = await _client.GetAsync("alltemps");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var readTask = httpResponseMessage.Content.ReadAsStringAsync();
                readTask.Wait();
                var response = JsonConvert.DeserializeObject<List<WeatherViewModel>>(readTask.Result);

                weatherList.AddRange(response.Select(data =>
                    new WeatherViewModel
                        {date = data.date, temperatureC = data.temperatureC, timeUnixEpoch = data.timeUnixEpoch}));
            }

            return View(weatherList);
        }

        public async Task<IActionResult> WeatherWarmest()
        {
            var weatherData = new WeatherViewModel();
            _client.BaseAddress = new Uri("http://localhost:5000/");
            var httpResponseMessage = await _client.GetAsync("warmestday");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var readTask = httpResponseMessage.Content.ReadAsStringAsync();
                readTask.Wait();
                var response = JsonConvert.DeserializeObject<WeatherViewModel>(readTask.Result);

                weatherData = new WeatherViewModel {date = response.date, temperatureC = response.temperatureC};
            }

            return View(weatherData);
        }

        public async Task<IActionResult> WeatherColdest()
        {
            var weatherData = new WeatherViewModel();
            _client.BaseAddress = new Uri("http://localhost:5000/");
            var httpResponseMessage = await _client.GetAsync("coldestday");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var readTask = httpResponseMessage.Content.ReadAsStringAsync();
                readTask.Wait();
                var response = JsonConvert.DeserializeObject<WeatherViewModel>(readTask.Result);

                weatherData = new WeatherViewModel {date = response.date, temperatureC = response.temperatureC};
            }

            return View(weatherData);
        }

        public async Task<IActionResult> WeatherAverage()
        {
            var weatherData = new WeatherViewModel();
            using (var client = new HttpClient())
            {
                _client.BaseAddress = new Uri("http://localhost:5000/");
                var httpResponseMessage = await _client.GetAsync("average");

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var readTask = httpResponseMessage.Content.ReadAsStringAsync();
                    readTask.Wait();
                    var response = JsonConvert.DeserializeObject<decimal>(readTask.Result);

                    weatherData = new WeatherViewModel {temperatureC = response};
                }
            }

            return View(weatherData);
        }
    }
}