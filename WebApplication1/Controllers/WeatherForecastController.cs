using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
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
        private readonly IGeneric<Class1> class1;

        //private readonly IMapper _mapper;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IGeneric<Class1> class1)
        {
            _logger = logger;
            this.class1 = class1;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            class1.Process(null);
            //var x = _mapper.Map<SampleMapFrom, SampleMapTo>(null, null);
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
