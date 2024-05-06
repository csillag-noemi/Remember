using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private static List<string> _messages = new List<string>();
        private readonly ILogger<MessagesController> _logger;

        public MessagesController(ILogger<MessagesController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] string message)
        {
            _messages.Add(message);
            _logger.LogInformation($"Received message: {message}");
            return Ok("Message received");
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInformation($"Sending back {_messages.Count} messages.");
            return _messages;
        }
    }
}
