using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Remember
{
    public class HttpServer
    {
        private readonly HttpListener _listener;

        public HttpServer()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://*:5000/"); // Change localhost to *
        }

        public void Start()
        {
            _listener.Start();
            Console.WriteLine("Server started. Press enter to stop.");

            // Start handling incoming requests asynchronously
            Task.Run(HandleIncomingRequestsAsync);

            Console.ReadLine();
            _listener.Stop();
        }

        private async Task HandleIncomingRequestsAsync()
        {
            while (_listener.IsListening)
            {
                try
                {
                    // Wait for a request to come in
                    HttpListenerContext context = await _listener.GetContextAsync();

                    // Process the request asynchronously
                    await HandleRequestAsync(context);
                }
                catch (HttpListenerException)
                {
                    // Handle exceptions, if any
                }
            }
        }

        private async Task HandleRequestAsync(HttpListenerContext context)
        {
            // Implement logic to handle incoming requests
            // You can parse the request URL and data here and send back appropriate responses.
            // For example:
            var responseString = "Hello from server!";
            await SendResponseAsync(context, responseString);
        }

        private async Task SendResponseAsync(HttpListenerContext context, string responseString, int statusCode = 200)
        {
            var buffer = Encoding.UTF8.GetBytes(responseString);

            var response = context.Response;
            response.StatusCode = statusCode;
            response.ContentType = "text/plain";
            response.ContentLength64 = buffer.Length;

            await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            response.Close();
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
