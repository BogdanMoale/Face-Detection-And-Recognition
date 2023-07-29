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
    public partial class StartScreen : Form
    {
        CustomBluetoothService bluetoothService = null;
        private BluetoothConnectionResult serviceResult = null;
        public StartScreen()
        {
            InitializeComponent();
            MailConfiguration mailConfig = new MailConfiguration();
            mailConfig.Show();
            mailConfig.Close();

        }

        private void btnTraining_Click(object sender, EventArgs e)
        {
            //this.Hide();
            /*
            var trainingModule = new TrainingModule();
            trainingModule.Closed += (s, args) => this.Close();
            trainingModule.Show();
            */
            TrainingModule trainingModule = new TrainingModule();
            trainingModule.Closed += (s, args) => this.Close();
            trainingModule.Show();
            AfisareInRichTextBox("Modulul de antrenare a fost incarcat cu succes.");
            

        }

        private void btnRecognizer_Click(object sender, EventArgs e)
        {
            Recognizer recognizerModule = new Recognizer();
            recognizerModule.Show();
            //this.Hide();
            AfisareInRichTextBox("Modulul de recunoastere a fost incarcat cu succes.");

        }

        public void AfisareInRichTextBox(string output)
        {
            if (!string.IsNullOrWhiteSpace(infoRichTextBox1.Text))
            {
                infoRichTextBox1.AppendText("\r\n" + output);
            }
            else
            {
                infoRichTextBox1.AppendText(output);
            }
            infoRichTextBox1.ScrollToCaret();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var BazaDeDate = new BazaDeDate();
            //BazaDeDate.Closed += (s, args) => this.Close();
            BazaDeDate.Show();
            AfisareInRichTextBox("Baza de date a fost incarcata cu succes.");
        }

        private void btnDespre_Click(object sender, EventArgs e)
        {
            MailConfiguration mailConfig = new MailConfiguration();
            mailConfig.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //var DetectareFataDinFoto = new DetectareFataDinFotografie();
            //DetectareFataDinFoto.Closed += (s, args) => this.Close();
            //DetectareFataDinFoto.Show();
            DetectareFataDinFotografie detectFace = new DetectareFataDinFotografie();
            detectFace.Show();
            AfisareInRichTextBox("Imagine Incarcata");
        }

        private void btnConectareBluetooth_Click(object sender, EventArgs e)
        {
            //var modulBluetooth = new BluetoothForm();
           // modulBluetooth.Closed += (s, args) => this.Close();
            //modulBluetooth.Show();
            //AfisareInRichTextBox("Modulul bluetooth a fost incarcat");

            BluetoothForm bForm = new BluetoothForm(bluetoothService, serviceResult);
            var dialogResult = bForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                this.bluetoothService = bForm.bluetoothService;
                this.serviceResult = bForm.serviceResult;
            }
            bForm.Show();
            //this.Hide();
            AfisareInRichTextBox("Modulul bluetooth a fost incarcat cu succes.");
        }

        private void StartScreen_Load(object sender, EventArgs e)
        {
            
        }
    }
}
