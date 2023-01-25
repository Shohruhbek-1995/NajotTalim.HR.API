using Microsoft.AspNetCore.Mvc;

namespace NajotTalim.HR.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        [MyCustomAttribute(MyCustomProp ="testvalue")]

        public Weather Post([FromBody] Region region)
        {
            if (region.Country == "Uzbekistan" && region.City == "Toshkent")
            {
                return new Weather { Rainy = false, Cloudy = false, Sunny = true, Windy = false };

            }
            else
            {
                return new Weather { Rainy = true, Cloudy = true, Sunny = false, Windy = true };

            }
        }
    }

    public class MyCustomAttribute : Attribute
        {
        public string MyCustomProp { get; set; }
        }

}