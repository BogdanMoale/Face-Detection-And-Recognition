namespace FaceRecognition
{
    partial class Recognizer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Recognizer));
            this.btnStartRecognize = new System.Windows.Forms.Button();
            this.imageBoxRecognizer = new Emgu.CV.UI.ImageBox();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.textBoxData = new System.Windows.Forms.TextBox();
            this.textBoxTimp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnSosire = new System.Windows.Forms.Button();
            this.btnPlecare = new System.Windows.Forms.Button();
            this.textBoxBrowse = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.GenerareRaport = new System.Windows.Forms.Button();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.treshValLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxRecognizer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartRecognize
            // 
            this.btnStartRecognize.Location = new System.Drawing.Point(12, 256);
            this.btnStartRecognize.Name = "btnStartRecognize";
            this.btnStartRecognize.Size = new System.Drawing.Size(66, 23);
            this.btnStartRecognize.TabIndex = 0;
            this.btnStartRecognize.Text = "Start";
            this.btnStartRecognize.UseVisualStyleBackColor = true;
            this.btnStartRecognize.Click += new System.EventHandler(this.btnStartRecognize_Click);
            // 
            // imageBoxRecognizer
            // 
            this.imageBoxRecognizer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxRecognizer.Location = new System.Drawing.Point(12, 10);
            this.imageBoxRecognizer.Name = "imageBoxRecognizer";
            this.imageBoxRecognizer.Size = new System.Drawing.Size(320, 240);
            this.imageBoxRecognizer.TabIndex = 2;
            this.imageBoxRecognizer.TabStop = false;
            // 
            // imageBox1
            // 
            this.imageBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox1.Location = new System.Drawing.Point(338, 142);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(100, 100);
            this.imageBox1.TabIndex = 3;
            this.imageBox1.TabStop = false;
            // 
            // textBoxData
            // 
            this.textBoxData.Location = new System.Drawing.Point(489, 206);
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.ReadOnly = true;
            this.textBoxData.Size = new System.Drawing.Size(104, 20);
            this.textBoxData.TabIndex = 23;
            // 
            // textBoxTimp
            // 
            this.textBoxTimp.Location = new System.Drawing.Point(490, 171);
            this.textBoxTimp.Name = "textBoxTimp";
            this.textBoxTimp.ReadOnly = true;
            this.textBoxTimp.Size = new System.Drawing.Size(104, 20);
            this.textBoxTimp.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(453, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(453, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Ora";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnSosire
            // 
            this.btnSosire.Location = new System.Drawing.Point(93, 256);
            this.btnSosire.Name = "btnSosire";
            this.btnSosire.Size = new System.Drawing.Size(67, 23);
            this.btnSosire.TabIndex = 27;
            this.btnSosire.Text = "Sosire";
            this.btnSosire.UseVisualStyleBackColor = true;
            this.btnSosire.Click += new System.EventHandler(this.btnSosire_Click);
            // 
            // btnPlecare
            // 
            this.btnPlecare.Location = new System.Drawing.Point(169, 256);
            this.btnPlecare.Name = "btnPlecare";
            this.btnPlecare.Size = new System.Drawing.Size(73, 23);
            this.btnPlecare.TabIndex = 28;
            this.btnPlecare.Text = "Plecare";
            this.btnPlecare.UseVisualStyleBackColor = true;
            this.btnPlecare.Click += new System.EventHandler(this.btnPlecare_Click);
            // 
            // textBoxBrowse
            // 
            this.textBoxBrowse.Location = new System.Drawing.Point(93, 312);
            this.textBoxBrowse.Name = "textBoxBrowse";
            this.textBoxBrowse.ReadOnly = true;
            this.textBoxBrowse.Size = new System.Drawing.Size(469, 20);
            this.textBoxBrowse.TabIndex = 29;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(12, 309);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 30;
            this.btnBrowse.Text = "Schimba";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // GenerareRaport
            // 
            this.GenerareRaport.Location = new System.Drawing.Point(259, 256);
            this.GenerareRaport.Name = "GenerareRaport";
            this.GenerareRaport.Size = new System.Drawing.Size(73, 23);
            this.GenerareRaport.TabIndex = 31;
            this.GenerareRaport.Text = "Generare";
            this.GenerareRaport.UseVisualStyleBackColor = true;
            this.GenerareRaport.Click += new System.EventHandler(this.GenerareRaport_Click);
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(338, 261);
            this.trackBar.Maximum = 7000;
            this.trackBar.Minimum = 100;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(100, 45);
            this.trackBar.TabIndex = 32;
            this.trackBar.TickFrequency = 50;
            this.trackBar.Value = 2500;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(448, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Treshold:";
            // 
            // treshValLabel
            // 
            this.treshValLabel.AutoSize = true;
            this.treshValLabel.Location = new System.Drawing.Point(506, 275);
            this.treshValLabel.Name = "treshValLabel";
            this.treshValLabel.Size = new System.Drawing.Size(0, 13);
            this.treshValLabel.TabIndex = 34;
            // 
            // Recognizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(606, 353);
            this.Controls.Add(this.treshValLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.GenerareRaport);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.textBoxBrowse);
            this.Controls.Add(this.btnPlecare);
            this.Controls.Add(this.btnSosire);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTimp);
            this.Controls.Add(this.textBoxData);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.imageBoxRecognizer);
            this.Controls.Add(this.btnStartRecognize);
            this.Name = "Recognizer";
            this.Text = "Modul recunoastere";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Recognizer_FormClosed);
            this.Load += new System.EventHandler(this.Recognizer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxRecognizer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartRecognize;
        private Emgu.CV.UI.ImageBox imageBoxRecognizer;
        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.TextBox textBoxData;
        private System.Windows.Forms.TextBox textBoxTimp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnSosire;
        private System.Windows.Forms.Button btnPlecare;
        private System.Windows.Forms.TextBox textBoxBrowse;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button GenerareRaport;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label treshValLabel;
    }
}