using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using wowments_api.Model;

namespace wowments_api.Controllers {
    [ApiController]
    [AllowAnonymous]
    [Route ("[controller]")]
    public class WeatherForecastController : ControllerBase {
        private readonly WowMents_DevContext _context;
        private static readonly string[] Summaries = new [] {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController (
            ILogger<WeatherForecastController> logger, WowMents_DevContext context
            ) {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get () {
            try {

                var b = _context.Permissions.FirstOrDefault ();

                var entity = new Permissions () {
                    Id = Guid.NewGuid (),
                    Name = "Sample",
                    CreatedOn = DateTime.UtcNow
                };

                _context.Add (entity);
                _context.SaveChanges ();

                var rng = new Random ();
                return Enumerable.Range (1, 5).Select (index => new WeatherForecast {
                        Date = DateTime.Now.AddDays (index),
                            TemperatureC = rng.Next (-20, 55),
                            Summary = Summaries[rng.Next (Summaries.Length)]
                    })
                    .ToArray ();
            } catch (Exception ex) {
                return null;
            }
        }

        [HttpGet ("GetStringHash")]
        public string GetStringHash () {
            try {
                return "Test Api";
            } catch (Exception ex) {
               throw ex;
            }
        }
    }
}