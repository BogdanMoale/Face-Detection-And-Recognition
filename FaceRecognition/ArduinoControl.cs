using System;
using System.Windows.Forms;

namespace FaceRecognition
{
    public partial class ArduinoControl : Form
    {
        public CustomBluetoothService bluetoothService;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="bluetoothService"></param>
        public ArduinoControl(CustomBluetoothService bluetoothService)
        {
            InitializeComponent();
            // Assigned the previous opened connection
            this.bluetoothService = bluetoothService;

            // Ardiuno commands
            button1.Tag = 10;
            button2.Tag = 11;

        }

        /// <summary>
        /// When an button is presed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendData_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            byte data = Convert.ToByte(button.Tag);

            bluetoothService.SendData(data);
        }
    }
}
