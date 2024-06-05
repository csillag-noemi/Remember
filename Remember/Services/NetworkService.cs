using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Remember.Services
{
    public class NetworkService
    {
        private static readonly object lockObject = new object();
        private static NetworkService instance;

        public event Action<string> MessageReceived;

        private TcpListener tcpListener;
        private Thread listenerThread;
        private CancellationTokenSource cancellationTokenSource;

        // Private constructor to prevent instantiation
        private NetworkService()
        {
            // Initialize your network service here
            tcpListener = new TcpListener(System.Net.IPAddress.Any, 9999);
        }

        // Public static method to get the singleton instance
        public static NetworkService GetInstance()
        {
            // Double-checked locking for thread safety
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new NetworkService();
                    }
                }
            }
            return instance;
        }

        // Start the network service
        public void Start()
        {
            tcpListener = new TcpListener(IPAddress.Any, 1025);
            tcpListener.Start();
            cancellationTokenSource = new CancellationTokenSource();

            listenerThread = new Thread(() => RunListener(cancellationTokenSource.Token))
            {
                IsBackground = true
            };
            listenerThread.Start();
        }

        // Run the listener loop
        private void RunListener(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    if (tcpListener.Pending())
                    {
                        TcpClient client = tcpListener.AcceptTcpClient();
                        Thread clientThread = new Thread(HandleClient);
                        clientThread.Start(client);
                    }
                    else
                    {
                        Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex) when (ex is SocketException || ex is InvalidOperationException)
            {
                Console.WriteLine("NetworkService stopped: " + ex.Message);
            }
        }

        // Handle individual client connections
        private void HandleClient(object clientObj)
        {
            TcpClient client = (TcpClient)clientObj;
            var stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            try
            {
                string message;
                while ((message = reader.ReadLine()) != null)
                {
                    Console.WriteLine($"Received message: {message} from {client.Client.RemoteEndPoint}");
                    MessageReceived?.Invoke(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error handling client {client.Client.RemoteEndPoint}: {ex.Message}");
            }
        }

        // Stop the network service
        public void Stop()
        {
            if (tcpListener != null)
            {
                cancellationTokenSource.Cancel();
                tcpListener.Stop();
                tcpListener = null;
            }

            if (listenerThread != null)
            {
                listenerThread.Join();
                listenerThread = null;
            }
        }
    }
}
