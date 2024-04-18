using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace AngularMvcApp.Controllers
{
    public class UserData
    {
        public required string LoginName { get; set; }
    }

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> logger;

        public DataController(ILogger<DataController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult<UserData> GetUserDataAuthenticated()
        {
            var result = new UserData()
            {
                LoginName = this.User.Identity!.Name!
            };

            this.logger.LogDebug("Login name: {LoginName}", result.LoginName);

            return this.Ok(result);
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMemoryCache _memoryCache;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var cacheKey = "weatherForecastList";
            if (!_memoryCache.TryGetValue(cacheKey, out IEnumerable<WeatherForecast>? weatherForecastList))
            {

                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();

                Console.WriteLine("Data from API (cache miss)");
            }
            else
            {
                Console.WriteLine("Data from CACHE (cache hit)");
            }

            return weatherForecastList!;
        }
    }
}