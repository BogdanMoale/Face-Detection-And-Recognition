using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System;


namespace FaceRecognition
{
    public class CustomBluetoothService
    {
        private BluetoothClient bluetoothClient;
        public bool ok = true;
       
        //construcor
        public CustomBluetoothService()
        {
            try
            {
                bluetoothClient = new BluetoothClient();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(string.Format("Nu exista niciun modul bluetooth pe acest dispozitiv. Conectati un modul bluetooth si incercati din nou"), "Avertizare");
            }
            
        }

        //aici stochez dispozitivele bluetooth
        public BluetoothDeviceInfo[] Devices { get; set; }


        //scanare dispozitive
        public void ScanDevices()
        {
            Disconnect();
            Devices = bluetoothClient.DiscoverDevices();
        }


        //conexiunea catre o adresa bluetooth
        public BluetoothConnectionResult Connect(object address)
        {
            var result = new BluetoothConnectionResult();

            try
            {
                if (address is BluetoothAddress bluetoothAddress)
                {
                    var endPoint = new BluetoothEndPoint(bluetoothAddress, BluetoothService.SerialPort);
                    bluetoothClient.Connect(endPoint);

                    result.IsSuccess = true;
                }
                else
                {
                    throw new Exception("Adresa bluetooth incorecta!");
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }

            return result;
        }

        //deconectare dispozitiv
        public void Disconnect()
        {
            if (bluetoothClient != null)
            {
                if (bluetoothClient.Connected)
                {
                    bluetoothClient.Close();
                    bluetoothClient.Dispose();

                    bluetoothClient = new BluetoothClient();
                }
            }
        }

        //transmitere date
        public void SendData(byte value)
        {
            try
            {
                var stream = bluetoothClient.GetStream();
                stream.WriteByte(value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class BluetoothConnectionResult
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}
