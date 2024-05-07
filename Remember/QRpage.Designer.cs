namespace Remember
{
    partial class QRpage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QRpage));
            this.backButton = new System.Windows.Forms.Button();
            this.qrPicBox = new System.Windows.Forms.PictureBox();
            this.startConn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.qrPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(14, 14);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(119, 41);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // qrPicBox
            // 
            this.qrPicBox.BackColor = System.Drawing.Color.Transparent;
            this.qrPicBox.Location = new System.Drawing.Point(242, 104);
            this.qrPicBox.Name = "qrPicBox";
            this.qrPicBox.Size = new System.Drawing.Size(458, 336);
            this.qrPicBox.TabIndex = 1;
            this.qrPicBox.TabStop = false;
            // 
            // startConn
            // 
            this.startConn.Location = new System.Drawing.Point(363, 467);
            this.startConn.Name = "startConn";
            this.startConn.Size = new System.Drawing.Size(210, 47);
            this.startConn.TabIndex = 2;
            this.startConn.Text = "Start Connection";
            this.startConn.UseVisualStyleBackColor = true;
            this.startConn.Click += new System.EventHandler(this.startConn_Click);
            // 
            // QRpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(945, 542);
            this.Controls.Add(this.startConn);
            this.Controls.Add(this.qrPicBox);
            this.Controls.Add(this.backButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QRpage";
            this.Text = "Connect to Phone";
            this.Load += new System.EventHandler(this.QRPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qrPicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.PictureBox qrPicBox;
        private System.Windows.Forms.Button startConn;
    }
}