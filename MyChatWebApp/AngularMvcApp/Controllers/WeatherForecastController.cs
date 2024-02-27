using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

    public class TestController : Controller
    {

        public TestController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ContentResult AjaxMethod(string name)
        {
            var result = new UserData()
            {
                LoginName = this.User.Identity!.Name!
            };

            string currentDateTime = string.Format("Hello {0}.\nCurrent DateTime: {1}", name, DateTime.Now.ToString());
            return Content(currentDateTime);
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
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