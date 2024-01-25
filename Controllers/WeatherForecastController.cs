using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System;

namespace FreelancerProjectAngular.Controllers
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

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            //CityFileStructure cityFileStructure = new CityFileStructure();

            //cityFileStructure.CityNames.Add("New york");
            //cityFileStructure.CityNames.Add("Berlin");
            //cityFileStructure.CityNames.Add("Dubai");

            //string jsonString = JsonSerializer.Serialize(cityFileStructure);
            //string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "CityFiles");

            //// Full path to the file
            //string filePath = Path.Combine(folderPath, "cities.json");

            //// Write to the file
            //using (StreamWriter writer = new StreamWriter(filePath))
            //{
            //    writer.Write(jsonString);
            //}


            CityFileUtils.AddCity("5ra");
            CityFileUtils.AddCity("zrba");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}