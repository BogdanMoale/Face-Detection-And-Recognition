using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceRecognition
{
    public partial class MailConfiguration : Form
    {
        public MailConfiguration()
        {
            InitializeComponent();

        }

        private void MailConfiguration_Load(object sender, EventArgs e)
        {
            //textBoxFrom.Text = "aplicatie.recunoastere.fata.@gmail.com";
            //textBoxPassw.Text = "b1o2g3b1o2g3";
            textBoxPassw.PasswordChar = '*';
            //textBoxTo.Text = "moalebogdan147@gmail.com";
            //textBoxSmtp.Text= "smtp.gmail.com";
            //textBoxPort.Text = "587";
            loadValues();
            updateMail();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            saveValues();
            updateMail();
            MessageBox.Show("Setariile au fost actualizate!");
        }

        void updateMail()
        {
            SetEmail.mailFrom = textBoxFrom.Text;
            SetEmail.maillPassword = textBoxPassw.Text;
            SetEmail.maillTo = textBoxTo.Text;
            SetEmail.maillSmtpAdress = textBoxSmtp.Text;
            SetEmail.maillPort = textBoxPort.Text;
        }

        public void loadValues()
        {
            textBoxFrom.Text = Properties.Settings.Default.txtFrom;
            textBoxPassw.Text = Properties.Settings.Default.txtPassw;
            textBoxTo.Text = Properties.Settings.Default.txtTo;
            textBoxSmtp.Text = Properties.Settings.Default.txtSmtp;
            textBoxPort.Text = Properties.Settings.Default.txtPort;
        }

        public void saveValues()
        {
            Properties.Settings.Default.txtFrom = textBoxFrom.Text;
            Properties.Settings.Default.txtPassw = textBoxPassw.Text;
            Properties.Settings.Default.txtTo = textBoxTo.Text;
            Properties.Settings.Default.txtSmtp = textBoxSmtp.Text;
            Properties.Settings.Default.txtPort = textBoxPort.Text;
            Properties.Settings.Default.Save();
        }
    }
}
