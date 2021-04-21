using Microsoft.AspNetCore.Mvc;

namespace TopicTweets.Controllers
{
    /// <summary>
    /// Application helth check
    /// </summary>
    public class HealthCheckController : ControllerBase
    {
        /// <summary> Default health check </summary>
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}