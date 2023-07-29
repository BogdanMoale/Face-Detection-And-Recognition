namespace FaceRecognition
{
    partial class BluetoothForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BluetoothForm));
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.devicesBluetoothListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(24, 121);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(84, 28);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Conectare";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(24, 174);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(84, 32);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "Deconectare";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(24, 69);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(84, 31);
            this.btnScan.TabIndex = 2;
            this.btnScan.Text = "Scanare";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // devicesBluetoothListBox
            // 
            this.devicesBluetoothListBox.FormattingEnabled = true;
            this.devicesBluetoothListBox.Location = new System.Drawing.Point(153, 69);
            this.devicesBluetoothListBox.Name = "devicesBluetoothListBox";
            this.devicesBluetoothListBox.Size = new System.Drawing.Size(142, 147);
            this.devicesBluetoothListBox.TabIndex = 3;
            this.devicesBluetoothListBox.SelectedIndexChanged += new System.EventHandler(this.devicesBluetoothListBox_SelectedIndexChanged);
            // 
            // BluetoothForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(321, 238);
            this.Controls.Add(this.devicesBluetoothListBox);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Name = "BluetoothForm";
            this.Text = "BluetoothForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.ListBox devicesBluetoothListBox;
    }
}