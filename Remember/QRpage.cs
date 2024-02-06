using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;

namespace Remember
{
    public partial class QRpage : Form
    {
        public QRpage()
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
            // Specify the content for the QR code (local IP address)
            string localIpAddress = HttpServer.GetLocalIPAddress();
            string qrCodeContent = $"http://{localIpAddress}:5000";

            // Generate and display the QR code
            GenerateQRCode(qrCodeContent);
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
