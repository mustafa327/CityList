using Microsoft.AspNetCore.Mvc;

namespace FreelancerProjectAngular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        [HttpGet("AddCity")]
        public IActionResult AddCity(string cityName)
        {
            CityFileUtils.AddCity(cityName);
            return Ok("City has been added");
        }

        [HttpGet("RemoveCity")]
        public IActionResult RemoveCity(string cityName)
        {
            CityFileUtils.RemoveCity(cityName);
            return Ok("City has been added");
        }

        [HttpGet("ListCity")]
        public IActionResult ListCity()
        {
            var file = CityFileUtils.LoadFile();
            return Ok(file.CityNames);
        }
    }
}
