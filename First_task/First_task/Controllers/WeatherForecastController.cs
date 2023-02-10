using Microsoft.AspNetCore.Mvc;
using System;

namespace First_task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<string> Get()
        {
            return Summaries;
        }

        [HttpGet("index")]
        public string GetIndex(int index)
        {
            if (index < 0 || index >= Summaries.Count)
                return "Неправильный индекс!!";

            return Summaries[index];
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            if(name == null)
                return BadRequest("Пустое поле!");

            Summaries.Add(name);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int index, string name) 
        {
            if (name == null)
                return BadRequest("Пустое поле!");

            if (index < 0 || index >= Summaries.Count)
                return BadRequest("Неправильный индекс!");

            Summaries[index] = name;
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count)
                return BadRequest("Неправильный индекс!");

            Summaries.RemoveAt(index);
            return Ok();
        }
    }
}