namespace FaceRecognition
{
    partial class StartScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartScreen));
            this.btnTraining = new System.Windows.Forms.Button();
            this.btnRecognizer = new System.Windows.Forms.Button();
            this.infoRichTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnDataBase = new System.Windows.Forms.Button();
            this.btnDespre = new System.Windows.Forms.Button();
            this.btnDetectFromPhoto = new System.Windows.Forms.Button();
            this.btnConectareBluetooth = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTraining
            // 
            this.btnTraining.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTraining.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnTraining.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraining.ForeColor = System.Drawing.Color.Black;
            this.btnTraining.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTraining.Location = new System.Drawing.Point(26, 22);
            this.btnTraining.Name = "btnTraining";
            this.btnTraining.Size = new System.Drawing.Size(149, 70);
            this.btnTraining.TabIndex = 0;
            this.btnTraining.Text = "Antrenare";
            this.btnTraining.UseVisualStyleBackColor = true;
            this.btnTraining.Click += new System.EventHandler(this.btnTraining_Click);
            // 
            // btnRecognizer
            // 
            this.btnRecognizer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRecognizer.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecognizer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnRecognizer.Location = new System.Drawing.Point(26, 115);
            this.btnRecognizer.Name = "btnRecognizer";
            this.btnRecognizer.Size = new System.Drawing.Size(149, 70);
            this.btnRecognizer.TabIndex = 1;
            this.btnRecognizer.Text = "Recunoastere";
            this.btnRecognizer.UseVisualStyleBackColor = true;
            this.btnRecognizer.Click += new System.EventHandler(this.btnRecognizer_Click);
            // 
            // infoRichTextBox1
            // 
            this.infoRichTextBox1.Location = new System.Drawing.Point(209, 235);
            this.infoRichTextBox1.Name = "infoRichTextBox1";
            this.infoRichTextBox1.ReadOnly = true;
            this.infoRichTextBox1.Size = new System.Drawing.Size(303, 65);
            this.infoRichTextBox1.TabIndex = 2;
            this.infoRichTextBox1.Text = "";
            // 
            // btnDataBase
            // 
            this.btnDataBase.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDataBase.ForeColor = System.Drawing.Color.Black;
            this.btnDataBase.Location = new System.Drawing.Point(26, 299);
            this.btnDataBase.Name = "btnDataBase";
            this.btnDataBase.Size = new System.Drawing.Size(149, 70);
            this.btnDataBase.TabIndex = 3;
            this.btnDataBase.Text = "Accesare Baza Date Fotografi";
            this.btnDataBase.UseVisualStyleBackColor = true;
            this.btnDataBase.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDespre
            // 
            this.btnDespre.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDespre.Location = new System.Drawing.Point(209, 317);
            this.btnDespre.Name = "btnDespre";
            this.btnDespre.Size = new System.Drawing.Size(149, 52);
            this.btnDespre.TabIndex = 4;
            this.btnDespre.Text = "Configurare Mail";
            this.btnDespre.UseVisualStyleBackColor = true;
            this.btnDespre.Click += new System.EventHandler(this.btnDespre_Click);
            // 
            // btnDetectFromPhoto
            // 
            this.btnDetectFromPhoto.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetectFromPhoto.Location = new System.Drawing.Point(26, 205);
            this.btnDetectFromPhoto.Name = "btnDetectFromPhoto";
            this.btnDetectFromPhoto.Size = new System.Drawing.Size(149, 70);
            this.btnDetectFromPhoto.TabIndex = 5;
            this.btnDetectFromPhoto.Text = "Detectare Fata Din Fotografie";
            this.btnDetectFromPhoto.UseVisualStyleBackColor = true;
            this.btnDetectFromPhoto.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnConectareBluetooth
            // 
            this.btnConectareBluetooth.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConectareBluetooth.Location = new System.Drawing.Point(364, 317);
            this.btnConectareBluetooth.Name = "btnConectareBluetooth";
            this.btnConectareBluetooth.Size = new System.Drawing.Size(149, 52);
            this.btnConectareBluetooth.TabIndex = 6;
            this.btnConectareBluetooth.Text = "Conectare Bluetooth";
            this.btnConectareBluetooth.UseVisualStyleBackColor = true;
            this.btnConectareBluetooth.Click += new System.EventHandler(this.btnConectareBluetooth_Click);
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(524, 399);
            this.Controls.Add(this.btnConectareBluetooth);
            this.Controls.Add(this.btnDetectFromPhoto);
            this.Controls.Add(this.btnDespre);
            this.Controls.Add(this.btnDataBase);
            this.Controls.Add(this.infoRichTextBox1);
            this.Controls.Add(this.btnRecognizer);
            this.Controls.Add(this.btnTraining);
            this.MaximizeBox = false;
            this.Name = "StartScreen";
            this.Text = "Aplicatie Recunoastere Fata";
            this.Load += new System.EventHandler(this.StartScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTraining;
        private System.Windows.Forms.Button btnRecognizer;
        public System.Windows.Forms.RichTextBox infoRichTextBox1;
        private System.Windows.Forms.Button btnDataBase;
        private System.Windows.Forms.Button btnDespre;
        private System.Windows.Forms.Button btnDetectFromPhoto;
        private System.Windows.Forms.Button btnConectareBluetooth;
    }
}