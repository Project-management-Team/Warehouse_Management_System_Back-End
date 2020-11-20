using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WarehouseManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("ping")]
        public ActionResult<string> Ping()
        {
            return "pong!";
        }
    }
}
