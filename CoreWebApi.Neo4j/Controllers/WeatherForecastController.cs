using Microsoft.AspNetCore.Mvc;

namespace CoreWebApi.Neo4j.Controllers
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

        //[HttpGet]
        //public async string GetNeo()
        //{
        //    // Aura queries use an encrypted connection using the "neo4j+s" protocol
        //    var uri = "neo4j+s://<Bolt url for Neo4j Aura instance>";

        //    var user = "<Username for Neo4j Aura instance>";
        //    var password = "<Password for Neo4j Aura instance>";

        //    using (var example = new Neo4jDriver(uri, user, password))
        //    {
        //        await example.CreateFriendship("Alice", "David");
        //        await example.FindPerson("Alice");
        //    }
        //}

        //public static async Task Main(string[] args)
        //{
        //    // Aura queries use an encrypted connection using the "neo4j+s" protocol
        //    var uri = "neo4j+s://<Bolt url for Neo4j Aura instance>";

        //    var user = "<Username for Neo4j Aura instance>";
        //    var password = "<Password for Neo4j Aura instance>";

        //    using (var example = new Neo4jDriver(uri, user, password))
        //    {
        //        await example.CreateFriendship("Alice", "David");
        //        await example.FindPerson("Alice");
        //    }
        //}
    }
}