using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // Add reference to Microsoft.Extensions.Logging
using System.Collections.Generic;
using System.Net.Http;

namespace RememberAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : Controller
    {
        private static List<string> _messages = new List<string>();
        private readonly ILogger<MessagesController> _logger; // Inject ILogger<T> interface

        // Inject ILogger<T> in the controller's constructor
        public MessagesController(ILogger<MessagesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetMessages()
        {
            return Ok(_messages);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] string message)
        {
            _logger.LogInformation($"Received message: {message}");
            await ForwardMessageToDesktopApp(message);
            _messages.Add(message);
            return Ok(message);
        }

        // Method to forward message to the desktop app
        private async Task ForwardMessageToDesktopApp(string message)
        {
            using (var httpClient = new HttpClient())
            {
                // Modify the URL based on your desktop app's API endpoint
                string desktopAppUrl = "http://localhost:8080/api/receiveMessage";

                // Create a new HttpRequestMessage
                var request = new HttpRequestMessage(HttpMethod.Post, desktopAppUrl);
                request.Content = new StringContent(message, System.Text.Encoding.UTF8, "application/json");

                // Send the HTTP request
                var response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Message forwarded to desktop app successfully.");
                }
                else
                {
                    _logger.LogError($"Failed to forward message to desktop app. Status code: {response.StatusCode}");
                }
            }
        }
    }
}
