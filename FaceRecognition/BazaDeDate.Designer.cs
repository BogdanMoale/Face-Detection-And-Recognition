namespace FaceRecognition
{
    partial class BazaDeDate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BazaDeDate));
            this.imageBoxDataBase = new Emgu.CV.UI.ImageBox();
            this.btnImagineInainte = new System.Windows.Forms.Button();
            this.btnImagineInapoi = new System.Windows.Forms.Button();
            this.textBoxNumePersoana = new System.Windows.Forms.TextBox();
            this.btnActualizareNume = new System.Windows.Forms.Button();
            this.btnStergePersoana = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxDataBase)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBoxDataBase
            // 
            this.imageBoxDataBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxDataBase.Location = new System.Drawing.Point(125, 52);
            this.imageBoxDataBase.Name = "imageBoxDataBase";
            this.imageBoxDataBase.Size = new System.Drawing.Size(100, 100);
            this.imageBoxDataBase.TabIndex = 3;
            this.imageBoxDataBase.TabStop = false;
            // 
            // btnImagineInainte
            // 
            this.btnImagineInainte.Location = new System.Drawing.Point(231, 88);
            this.btnImagineInainte.Name = "btnImagineInainte";
            this.btnImagineInainte.Size = new System.Drawing.Size(75, 23);
            this.btnImagineInainte.TabIndex = 4;
            this.btnImagineInainte.Text = ">";
            this.btnImagineInainte.UseVisualStyleBackColor = true;
            this.btnImagineInainte.Click += new System.EventHandler(this.ImagineInainte_Click);
            // 
            // btnImagineInapoi
            // 
            this.btnImagineInapoi.Location = new System.Drawing.Point(37, 88);
            this.btnImagineInapoi.Name = "btnImagineInapoi";
            this.btnImagineInapoi.Size = new System.Drawing.Size(82, 23);
            this.btnImagineInapoi.TabIndex = 5;
            this.btnImagineInapoi.Text = "<";
            this.btnImagineInapoi.UseVisualStyleBackColor = true;
            this.btnImagineInapoi.Click += new System.EventHandler(this.ImagineInapoi_Click);
            // 
            // textBoxNumePersoana
            // 
            this.textBoxNumePersoana.Location = new System.Drawing.Point(94, 158);
            this.textBoxNumePersoana.Name = "textBoxNumePersoana";
            this.textBoxNumePersoana.Size = new System.Drawing.Size(163, 20);
            this.textBoxNumePersoana.TabIndex = 6;
            // 
            // btnActualizareNume
            // 
            this.btnActualizareNume.Location = new System.Drawing.Point(94, 184);
            this.btnActualizareNume.Name = "btnActualizareNume";
            this.btnActualizareNume.Size = new System.Drawing.Size(73, 23);
            this.btnActualizareNume.TabIndex = 7;
            this.btnActualizareNume.Text = "Actualizare nume";
            this.btnActualizareNume.UseVisualStyleBackColor = true;
            this.btnActualizareNume.Click += new System.EventHandler(this.btnActualizareNume_Click);
            // 
            // btnStergePersoana
            // 
            this.btnStergePersoana.Location = new System.Drawing.Point(173, 184);
            this.btnStergePersoana.Name = "btnStergePersoana";
            this.btnStergePersoana.Size = new System.Drawing.Size(84, 23);
            this.btnStergePersoana.TabIndex = 8;
            this.btnStergePersoana.Text = "Sterge";
            this.btnStergePersoana.UseVisualStyleBackColor = true;
            // 
            // BazaDeDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(329, 210);
            this.Controls.Add(this.btnStergePersoana);
            this.Controls.Add(this.btnActualizareNume);
            this.Controls.Add(this.textBoxNumePersoana);
            this.Controls.Add(this.btnImagineInapoi);
            this.Controls.Add(this.btnImagineInainte);
            this.Controls.Add(this.imageBoxDataBase);
            this.Name = "BazaDeDate";
            this.Text = "BazaDeDate";
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxDataBase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBoxDataBase;
        private System.Windows.Forms.Button btnImagineInainte;
        private System.Windows.Forms.Button btnImagineInapoi;
        private System.Windows.Forms.TextBox textBoxNumePersoana;
        private System.Windows.Forms.Button btnActualizareNume;
        private System.Windows.Forms.Button btnStergePersoana;
    }
}