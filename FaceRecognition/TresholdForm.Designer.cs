namespace FaceRecognition
{
    partial class TresholdForm
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
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTreshVal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(12, 12);
            this.trackBar.Maximum = 7000;
            this.trackBar.Minimum = 100;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(250, 45);
            this.trackBar.TabIndex = 33;
            this.trackBar.TickFrequency = 50;
            this.trackBar.Value = 100;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Treshold:";
            // 
            // labelTreshVal
            // 
            this.labelTreshVal.AutoSize = true;
            this.labelTreshVal.Location = new System.Drawing.Point(121, 60);
            this.labelTreshVal.Name = "labelTreshVal";
            this.labelTreshVal.Size = new System.Drawing.Size(0, 13);
            this.labelTreshVal.TabIndex = 35;
            // 
            // TresholdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 101);
            this.Controls.Add(this.labelTreshVal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBar);
            this.Name = "TresholdForm";
            this.Text = "TresholdForm";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelTreshVal;
    }
}