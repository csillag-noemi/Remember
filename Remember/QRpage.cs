using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;
using Remember.Services;

namespace Remember
{
    public partial class QRpage : Form
    {
        private NetworkService networkService;

        public QRpage(NetworkService networkService)
        {
            InitializeComponent();
            
        }

        private void GenerateQRCode(string content)
        {
            try
            {
                // Create a QR code writer
                BarcodeWriter barcodeWriter = new BarcodeWriter();
                barcodeWriter.Format = BarcodeFormat.QR_CODE;
                barcodeWriter.Options = new QrCodeEncodingOptions
                {
                    Width = 300,  // Set the width and height of the QR code
                    Height = 300,
                };

                // Generate the QR code
                Bitmap qrCodeBitmap = barcodeWriter.Write(content);

                // Set the QR code as the image for the PictureBox
                qrPicBox.Image = qrCodeBitmap;
            }
            catch(Exception ex) {
                MessageBox.Show("Error generating QR code: " + ex.Message);
            }

            
        }

        private void QRPage_Load(object sender, EventArgs e)
        {
            string ipAddress = GetLocalIPAddress();
            int port = 1025; // Example port number
            string qrCodeContent = $"{{\"ip\": \"{ipAddress}\", \"port\": {port}}}";
            GenerateQRCode(qrCodeContent);

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.BringToFront();
            dashboard.Activate();
            this.Close();
        }

        private string GetLocalIPAddress()
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


        private void startConn_Click(object sender, EventArgs e)
        {
            networkService = NetworkService.GetInstance();
            networkService.Start();
            if (networkService != null)
            {
                networkService.MessageReceived += NetworkService_MessageReceived;
            }

        }
        private void NetworkService_MessageReceived(string message)
        {
            Invoke((MethodInvoker)delegate
            {
                MessageBox.Show(message, "Message Received", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }
    }
}
