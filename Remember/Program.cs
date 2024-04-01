using Microsoft.Data.Sqlite;
using System;
using System.Configuration;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Remember
{
    internal static class Program
    {
        private static QRpage _qrPage;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (SqliteConnection conn = new SqliteConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {
                _qrPage = new QRpage();
                Application.Run(new MainForm(conn));
            }
        }
    }
}