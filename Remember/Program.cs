using Remember.Services;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace Remember
{
    internal static class Program
    {
        private static NetworkService networkService;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialize and start the network service
            networkService = NetworkService.GetInstance();
            Application.Run(new Dashboard());
            networkService.Stop();
        }
    }
}