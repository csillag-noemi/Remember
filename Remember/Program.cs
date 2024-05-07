using Microsoft.Data.Sqlite;
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

            using (SqliteConnection conn = new SqliteConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {
                Application.Run(new MainForm(conn));
            }

            networkService.Stop();
        }
    }
}