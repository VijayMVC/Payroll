namespace Payroll
{
    partial class CameraFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraFrm));
            this.btnSave = new System.Windows.Forms.Button();
            this.picCam1 = new System.Windows.Forms.PictureBox();
            this.comboBoxCameras = new System.Windows.Forms.ComboBox();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCam1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(438, 447);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Capture";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // picCam1
            // 
            this.picCam1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picCam1.InitialImage = ((System.Drawing.Image)(resources.GetObject("picCam1.InitialImage")));
            this.picCam1.Location = new System.Drawing.Point(0, 0);
            this.picCam1.Name = "picCam1";
            this.picCam1.Size = new System.Drawing.Size(621, 441);
            this.picCam1.TabIndex = 13;
            this.picCam1.TabStop = false;
            this.picCam1.Click += new System.EventHandler(this.picCam1_Click);
            // 
            // comboBoxCameras
            // 
            this.comboBoxCameras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCameras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCameras.FormattingEnabled = true;
            this.comboBoxCameras.Location = new System.Drawing.Point(161, 449);
            this.comboBoxCameras.Name = "comboBoxCameras";
            this.comboBoxCameras.Size = new System.Drawing.Size(216, 21);
            this.comboBoxCameras.TabIndex = 12;
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfig.Location = new System.Drawing.Point(525, 447);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(87, 23);
            this.btnConfig.TabIndex = 10;
            this.btnConfig.Text = "Configuration";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.Location = new System.Drawing.Point(89, 447);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(66, 23);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(12, 447);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(71, 23);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // CameraFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 482);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.picCam1);
            this.Controls.Add(this.comboBoxCameras);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.MinimumSize = new System.Drawing.Size(640, 520);
            this.Name = "CameraFrm";
            this.Text = "Camera";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CameraFrm_FormClosing);
            this.Load += new System.EventHandler(this.CameraFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCam1)).EndInit();
            this.ResumeLayout(false);

        }

        private void picCam1_Click(object sender, System.EventArgs e)
        {
            try
            {
                throw new System.NotImplementedException();
            }
            catch { }

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.PictureBox picCam1;
        private System.Windows.Forms.ComboBox comboBoxCameras;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
    }
}

