using InTheHand.Net.Sockets;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace FaceRecognition
{
    public partial class BluetoothForm : Form
    {

        public CustomBluetoothService bluetoothService;
        public BluetoothConnectionResult serviceResult;

        // Workers (async)
        private BackgroundWorker scanWorker;
        private BackgroundWorker connectionWorker;

        // folosit pentru a stoca dispozitivele gasite
        private BluetoothDeviceInfo[] bluetoothDevices => bluetoothService == null ? new BluetoothDeviceInfo[0] : bluetoothService.Devices;

        // folosit pentru verificarea conexiunii
        private bool bluetoothConnected => serviceResult == null ? false : serviceResult.IsSuccess;

        /// <summary>
        /// Contructor.
        /// </summary>
        /// <param name="bluetoothService"></param>
        /// <param name="serviceResult"></param>

        public BluetoothForm(CustomBluetoothService bluetoothService, BluetoothConnectionResult serviceResult)
        {

            InitializeComponent();

            // Stergere continut lista dispozitive
            //devicesBluetoothListBox.Items.Clear();

            // Activare buton scanare
            btnScan.Enabled = true;


            // Not opened a connection previously
            if (bluetoothService != null)
            {
                // Assigned the previous opened connection
                this.bluetoothService = bluetoothService;
                this.serviceResult = serviceResult;

                // Check if devices were found on previous runs.
                if (bluetoothDevices.Any())
                {
                    devicesBluetoothListBox.DataSource = bluetoothDevices;
                    devicesBluetoothListBox.DisplayMember = "DeviceName";
                    devicesBluetoothListBox.ValueMember = "DeviceAddress";
                }

                
                //dezactivare buton conectare si scanare
                btnConnect.Enabled = bluetoothConnected == true ? false : true;

                //activare buton deconectare
                btnDisconnect.Enabled = bluetoothConnected == true ? true : false;
            }
            else
            {
                // Creeare conexiune noua
                this.bluetoothService = new CustomBluetoothService();
                this.serviceResult = null;

                //Dezactivare buton conectare si deconectare
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = false;
            }

            scanWorker = new BackgroundWorker();
            scanWorker.DoWork += ScanWorker_DoWork;
            scanWorker.RunWorkerCompleted += ScanWorker_RunWorkerCompleted;

            connectionWorker = new BackgroundWorker();
            connectionWorker.DoWork += ConnectionWorker_DoWork;
            connectionWorker.RunWorkerCompleted += ConnectionWorker_RunWorkerCompleted;
        }

        /// <summary>
        /// Scanare
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnScan_Click(object sender, EventArgs e)
        {
            // Dezactivare buton scanare
            btnScan.Enabled = false;

            //Dezactivare buton conectare si deconectare
            btnConnect.Enabled = false;
            btnDisconnect.Enabled = false;

            scanWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Scanare dupa dispozitive bluetooth.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ScanWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Sterge lista cu dispozitive curente
            //devicesBluetoothListBox.Items.Clear();

            // Cauta dispozitive noi.
            bluetoothService.ScanDevices();
        }

        /// <summary>
        /// Scanarea dispozitivelor 100% completa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (bluetoothDevices.Any())
            {
                devicesBluetoothListBox.DataSource = bluetoothDevices;
                devicesBluetoothListBox.DisplayMember = "DeviceName";
                devicesBluetoothListBox.ValueMember = "DeviceAddress";
            }

            // Re-enable scan
            btnScan.Enabled = true;

            this.DialogResult = DialogResult.OK;
        }


        /// <summary>
        /// Conectare la bluetooth.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            // Dezactivare buton scanare
            btnScan.Enabled = false;

            //Dezactivare buton conectare si deconectare
            btnConnect.Enabled = false;
            btnDisconnect.Enabled = false;

            connectionWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Connectare in progres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            object address = null;

            devicesBluetoothListBox.Invoke((Action)(() =>
            {
                address = devicesBluetoothListBox.SelectedValue;
                e.Result = devicesBluetoothListBox.Text;
            }));

            serviceResult = bluetoothService.Connect(address);
        }

        /// <summary>
        /// Conectare reusita
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectionWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Success
            if (bluetoothConnected)
            {
                MessageBox.Show(string.Format("Connectat la {0}.", e.Result), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
                //Activare buton deconectare
                btnDisconnect.Enabled = true;

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(serviceResult.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //Activare buton conectare
                btnConnect.Enabled = true;
            }

            // Activare buton scanare
            btnScan.Enabled = true;
        }



        /// <summary>
        /// Deconectare client bluetooth
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            bluetoothService.Disconnect();
            btnScan.Enabled = false;
            btnDisconnect.Enabled = false;
            btnConnect.Enabled = true;

            // Tell application (window) something has changed with the connection
            this.DialogResult = DialogResult.OK;

            

        }

        /// <summary>
        /// Schimbarea selectiei in lista de dispozitive
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void devicesBluetoothListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Selectie valida
            if (devicesBluetoothListBox.SelectedIndex != -1)
            {
                btnConnect.Enabled = true;
            }
            else
            {
                btnConnect.Enabled = false;
            }
        }
    }
}
