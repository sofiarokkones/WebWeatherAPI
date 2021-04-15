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
                .Select(v => WeatherForecast.FromCsv(v))
                .ToList();
        }
    }
}