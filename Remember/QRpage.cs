using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Presentation;
using ZXing.QrCode;

namespace Remember
{
    public partial class QRpage : Form
    {
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
                if (ipAddress == null)
                {
                    MessageBox.Show("No valid IP address found for this machine.");
                    return;  // Early return if no IP address found
                }

                // Get the port number of your Web API server
                int port = 7009; // Replace this with the actual port number of your Web API server

                // Create a QR code writer
                ZXing.BarcodeWriter barcodeWriter = new ZXing.BarcodeWriter();
                barcodeWriter.Format = BarcodeFormat.QR_CODE;
                barcodeWriter.Options = new QrCodeEncodingOptions
                {
                    Width = 300,  // Set the width and height of the QR code
                    Height = 300,
                };


                // Generate the QR code content
                string qrCodeContent = $"https://{ipAddress}:{port}/api"; 

                // Generate the QR code
                Bitmap qrCodeBitmap = barcodeWriter.Write(qrCodeContent);

                // Set the QR code as the image for the PictureBox
                qrPicBox.Image = qrCodeBitmap;

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

        private void QRPage_Load(object sender, EventArgs e)
        {
            // Generate and display the QR code
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
