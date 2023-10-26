namespace Remember
{
    partial class Dashboard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.createSL = new System.Windows.Forms.Button();
            this.browseBtn = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.clearBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.closeMusicBtn = new System.Windows.Forms.Button();
            this.musicBtn = new System.Windows.Forms.Button();
            this.qrButton = new System.Windows.Forms.Button();
            this.musicLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFile";
            // 
            // createSL
            // 
            this.createSL.Location = new System.Drawing.Point(1183, 501);
            this.createSL.Margin = new System.Windows.Forms.Padding(4);
            this.createSL.Name = "createSL";
            this.createSL.Size = new System.Drawing.Size(140, 31);
            this.createSL.TabIndex = 1;
            this.createSL.Text = "Create SlideShow";
            this.createSL.UseVisualStyleBackColor = true;
            this.createSL.Click += new System.EventHandler(this.CreateSL_Click);
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(261, 501);
            this.browseBtn.Margin = new System.Windows.Forms.Padding(4);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(120, 31);
            this.browseBtn.TabIndex = 2;
            this.browseBtn.Text = "Browse";
            this.toolTip1.SetToolTip(this.browseBtn, "Click to browse photos");
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.listBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox.ForeColor = System.Drawing.SystemColors.Info;
            this.listBox.FormattingEnabled = true;
            this.listBox.HorizontalScrollbar = true;
            this.listBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listBox.ItemHeight = 16;
            this.listBox.Location = new System.Drawing.Point(11, 9);
            this.listBox.Margin = new System.Windows.Forms.Padding(4);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(370, 482);
            this.listBox.TabIndex = 3;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(136, 501);
            this.clearBtn.Margin = new System.Windows.Forms.Padding(4);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(120, 31);
            this.clearBtn.TabIndex = 4;
            this.clearBtn.Text = "Clear list";
            this.toolTip1.SetToolTip(this.clearBtn, "Click to clear all photos");
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(11, 501);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(4);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(120, 31);
            this.deleteBtn.TabIndex = 5;
            this.deleteBtn.Text = "Delete";
            this.toolTip1.SetToolTip(this.deleteBtn, "Click to delete the selected photo");
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(389, 9);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(933, 482);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 6;
            this.pictureBox.TabStop = false;
            // 
            // closeMusicBtn
            // 
            this.closeMusicBtn.BackColor = System.Drawing.Color.IndianRed;
            this.closeMusicBtn.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.closeMusicBtn.FlatAppearance.BorderSize = 0;
            this.closeMusicBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.closeMusicBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.closeMusicBtn.Location = new System.Drawing.Point(517, 501);
            this.closeMusicBtn.Margin = new System.Windows.Forms.Padding(4);
            this.closeMusicBtn.Name = "closeMusicBtn";
            this.closeMusicBtn.Size = new System.Drawing.Size(33, 31);
            this.closeMusicBtn.TabIndex = 14;
            this.closeMusicBtn.Text = "X";
            this.toolTip1.SetToolTip(this.closeMusicBtn, "Click to remove selected music");
            this.closeMusicBtn.UseVisualStyleBackColor = false;
            this.closeMusicBtn.Click += new System.EventHandler(this.CloseMusicBtn_Click);
            // 
            // musicBtn
            // 
            this.musicBtn.Location = new System.Drawing.Point(389, 501);
            this.musicBtn.Margin = new System.Windows.Forms.Padding(4);
            this.musicBtn.Name = "musicBtn";
            this.musicBtn.Size = new System.Drawing.Size(120, 31);
            this.musicBtn.TabIndex = 12;
            this.musicBtn.Text = "Add music";
            this.toolTip1.SetToolTip(this.musicBtn, "Click to browse music");
            this.musicBtn.UseVisualStyleBackColor = true;
            this.musicBtn.Click += new System.EventHandler(this.MusicBtn_Click);
            // 
            // qrButton
            // 
            this.qrButton.Location = new System.Drawing.Point(1033, 501);
            this.qrButton.Margin = new System.Windows.Forms.Padding(4);
            this.qrButton.Name = "qrButton";
            this.qrButton.Size = new System.Drawing.Size(142, 31);
            this.qrButton.TabIndex = 15;
            this.qrButton.Text = "Connect to Phone";
            this.toolTip1.SetToolTip(this.qrButton, "Click to generate a QR code");
            this.qrButton.UseVisualStyleBackColor = true;
            this.qrButton.Click += new System.EventHandler(this.QrButton_Click);
            // 
            // musicLbl
            // 
            this.musicLbl.AutoSize = true;
            this.musicLbl.BackColor = System.Drawing.Color.Transparent;
            this.musicLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.musicLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.musicLbl.Location = new System.Drawing.Point(559, 508);
            this.musicLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.musicLbl.Name = "musicLbl";
            this.musicLbl.Size = new System.Drawing.Size(0, 17);
            this.musicLbl.TabIndex = 13;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1332, 539);
            this.Controls.Add(this.qrButton);
            this.Controls.Add(this.closeMusicBtn);
            this.Controls.Add(this.musicLbl);
            this.Controls.Add(this.musicBtn);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.createSL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Dashboard";
            this.Text = "Remember";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Dashboard_FormClosed);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button createSL;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button musicBtn;
        private System.Windows.Forms.Label musicLbl;
        private System.Windows.Forms.Button closeMusicBtn;
        private System.Windows.Forms.Button qrButton;
    }
}