namespace FaceRecognition
{
    partial class TrainingModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrainingModule));
            this.imageBox = new Emgu.CV.UI.ImageBox();
            this.imageboxForDetectedFace = new Emgu.CV.UI.ImageBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pornireCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capturareFataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.antrenareFataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recunoastereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.antrenareBazaDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBoxAntrenare = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageboxForDetectedFace)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageBox
            // 
            this.imageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox.Location = new System.Drawing.Point(12, 86);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(320, 240);
            this.imageBox.TabIndex = 2;
            this.imageBox.TabStop = false;
            // 
            // imageboxForDetectedFace
            // 
            this.imageboxForDetectedFace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageboxForDetectedFace.Location = new System.Drawing.Point(403, 44);
            this.imageboxForDetectedFace.Name = "imageboxForDetectedFace";
            this.imageboxForDetectedFace.Size = new System.Drawing.Size(100, 100);
            this.imageboxForDetectedFace.TabIndex = 2;
            this.imageboxForDetectedFace.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(358, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nume:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(403, 147);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pornireCameraToolStripMenuItem,
            this.capturareFataToolStripMenuItem,
            this.antrenareFataToolStripMenuItem,
            this.recunoastereToolStripMenuItem,
            this.antrenareBazaDateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(531, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pornireCameraToolStripMenuItem
            // 
            this.pornireCameraToolStripMenuItem.Name = "pornireCameraToolStripMenuItem";
            this.pornireCameraToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.pornireCameraToolStripMenuItem.Text = "Pornire Camera";
            this.pornireCameraToolStripMenuItem.Click += new System.EventHandler(this.pornireCameraToolStripMenuItem_Click);
            // 
            // capturareFataToolStripMenuItem
            // 
            this.capturareFataToolStripMenuItem.Name = "capturareFataToolStripMenuItem";
            this.capturareFataToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.capturareFataToolStripMenuItem.Text = "Capturare fata";
            this.capturareFataToolStripMenuItem.Click += new System.EventHandler(this.capturareFataToolStripMenuItem_Click);
            // 
            // antrenareFataToolStripMenuItem
            // 
            this.antrenareFataToolStripMenuItem.Name = "antrenareFataToolStripMenuItem";
            this.antrenareFataToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.antrenareFataToolStripMenuItem.Text = "Antrenare fata";
            this.antrenareFataToolStripMenuItem.Click += new System.EventHandler(this.antrenareFataToolStripMenuItem_Click);
            // 
            // recunoastereToolStripMenuItem
            // 
            this.recunoastereToolStripMenuItem.Name = "recunoastereToolStripMenuItem";
            this.recunoastereToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.recunoastereToolStripMenuItem.Text = "Recunoastere";
            this.recunoastereToolStripMenuItem.Click += new System.EventHandler(this.recunoastereToolStripMenuItem_Click);
            // 
            // antrenareBazaDateToolStripMenuItem
            // 
            this.antrenareBazaDateToolStripMenuItem.Name = "antrenareBazaDateToolStripMenuItem";
            this.antrenareBazaDateToolStripMenuItem.Size = new System.Drawing.Size(124, 20);
            this.antrenareBazaDateToolStripMenuItem.Text = "Antrenare baza date";
            this.antrenareBazaDateToolStripMenuItem.Click += new System.EventHandler(this.antrenareBazaDateToolStripMenuItem_Click);
            // 
            // richTextBoxAntrenare
            // 
            this.richTextBoxAntrenare.BackColor = System.Drawing.Color.White;
            this.richTextBoxAntrenare.Location = new System.Drawing.Point(403, 188);
            this.richTextBoxAntrenare.Name = "richTextBoxAntrenare";
            this.richTextBoxAntrenare.Size = new System.Drawing.Size(100, 138);
            this.richTextBoxAntrenare.TabIndex = 9;
            this.richTextBoxAntrenare.Text = "";
            // 
            // TrainingModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(531, 338);
            this.Controls.Add(this.richTextBoxAntrenare);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageboxForDetectedFace);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TrainingModule";
            this.Text = "Modul Antrenare";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageboxForDetectedFace)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Emgu.CV.UI.ImageBox imageBox;
        private Emgu.CV.UI.ImageBox imageboxForDetectedFace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pornireCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem capturareFataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem antrenareFataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recunoastereToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem antrenareBazaDateToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBoxAntrenare;
    }
}

