using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;

namespace Remember
{
    public partial class QRpage : Form
    {
        public void DisplayMessage(string message)
        {
            MessageBox.Show(message, "Received Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public QRpage()
        {
            InitializeComponent();
        }

        private void GenerateQRCode()
        {
            try
            {
                // Generate a unique identifier for the desktop app
                string uniqueId = Guid.NewGuid().ToString();

                // Get the local IP address and a random port number
                IPAddress ipAddress = GetLocalIPAddress();
                int port = new Random().Next(49152, 65535);

                // Create a QR code writer
                BarcodeWriter barcodeWriter = new BarcodeWriter();
                barcodeWriter.Format = BarcodeFormat.QR_CODE;
                barcodeWriter.Options = new QrCodeEncodingOptions
                {
                    Width = 300,  // Set the width and height of the QR code
                    Height = 300,
                };

                // Generate the QR code content
                string qrCodeContent = $"http://{ipAddress}:{port}";

                // Generate the QR code
                Bitmap qrCodeBitmap = barcodeWriter.Write(qrCodeContent);

                // Set the QR code as the image for the PictureBox
                qrPicBox.Image = qrCodeBitmap;

                // Call the connectToApp method with the generated QR code content
                connectToApp(this, qrCodeContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating QR code: " + ex.Message);
            }
        }

        private IPAddress GetLocalIPAddress()
        {
            // Get all network interfaces
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            // Loop through the network interfaces to find the first non-loopback interface with a valid IP address
            foreach (NetworkInterface ni in interfaces)
            {
                if (ni.OperationalStatus == OperationalStatus.Up && ni.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    // Loop through the IP properties to find the first valid IP address
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            return ip.Address;
                        }
                    }
                }
            }

            // If no valid IP address is found, return null
            return null;
        }

        private static void connectToApp(QRpage qrPage, string qrCodeContent)
        {
            // Parse the IP address and port number from the QR code content
            string[] parts = qrCodeContent.Split(':');
            IPAddress ipAddress = IPAddress.Parse(parts[0]);
            int port = int.Parse(parts[1]);

            // Create a new TcpClient and connect to the Android app
            using (TcpClient client = new TcpClient())
            {
                try
                {
                    client.Connect(ipAddress, port);

                    // Get the network stream
                    NetworkStream networkStream = client.GetStream();

                    // Read the message from the Android app
                    byte[] messageBytes = new byte[1024];
                    int bytesRead = networkStream.Read(messageBytes, 0, messageBytes.Length);
                    string message = Encoding.ASCII.GetString(messageBytes, 0, bytesRead);


                    // Display the response in a message box
                    qrPage.DisplayMessage(message);
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.ConnectionRefused)
                    {
                        qrPage.DisplayMessage("The connection was refused by the Android app.");
                    }
                    else
                    {
                        qrPage.DisplayMessage("An error occurred while connecting to the Android app: " + ex.Message);
                    }
                }
            }
        }

        private void QRPage_Load(object sender, EventArgs e)
        {
            GenerateQRCode();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.BringToFront();
            dashboard.Activate();
            this.Close();
        }
    }
}
