using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApi.Neo4j.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Neo4jController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly Neo4jDriver _driver;
        public Neo4jController(IConfiguration configuration, Neo4jDriver driver)
        {
            _configuration = configuration;
            _driver = driver;
        }
        [HttpGet("FindPerson")]
        public async Task<IActionResult> FindPerson(string name)
        {
            var result = await _driver.FindPersonAsRecord(name);

            return StatusCode(200, result);
        }

    }
}
