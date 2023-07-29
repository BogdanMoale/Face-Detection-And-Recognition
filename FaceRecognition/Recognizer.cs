using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.IO.Ports;
using System.Threading;



namespace FaceRecognition
{
    public partial class Recognizer : Form
    {

        Image<Bgr, Byte> currentFrame;
        HaarCascade faceDetection;
        Image<Gray, byte> imageToGrayScale = null;
        int j = 0; // variabila pentru stocarea numarului de fete
        Capture captureImage;
        Image<Gray, byte> results = null;
        int NumLabels;
        int CountPersons;
        List<Image<Gray, byte>> trainingFaces = new List<Image<Gray, byte>>();//fata
        List<string> NamesOfPersons = new List<string>();//nume
        List<string> getPositionOfDetectedPerson = new List<string>();//nume
        String NameOfDetectedPerson = null;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        //initializare lista pentru salvarea numelui persoanei detectate
        List<string> NamePersons = new List<string>();
        bool isConnectedToArduino = false;
        String[] COMArduinoPorts;
        SerialPort port;
        EigenFaceRecognizerEngine eigenFaceClass = new EigenFaceRecognizerEngine();
        public double Treshold;

         static string caleBazaDateAngajati = Properties.Settings.Default.txtPath;
        // Excel excel1 = new Excel(caleBazaDateAngajati, 1);


        public Recognizer()
        {
            InitializeComponent();
            //SelectarePortArduino();
            faceDetection = new HaarCascade("haarcascade-frontalface-default.xml");
            LoadFacesFromDataBase();
            //deleteOld();
            saveDataBaseToExcel();
            //showTresholdForm();
        }

        private void btnStartRecognize_Click(object sender, EventArgs e)
        {
            captureImage = new Capture();
            captureImage.QueryFrame();
            Application.Idle += new EventHandler(CurrentFrameGrabber);
        }

        private void CurrentFrameGrabber(object sender, EventArgs e)
        {
            NamePersons.Add("");
            currentFrame = captureImage.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
           
            //convertirea imaginii in nuante de gri(grayscale)
            imageToGrayScale = currentFrame.Convert<Gray, Byte>();
            //detectarea fetei
            MCvAvgComp[][] facesDected = imageToGrayScale.DetectHaarCascade(
                faceDetection,
                1.2,
                //1.1,
                10,
                //3,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(20, 20));
            //verificare fiecare frame din imagebox si detecteaza fetele
            foreach (MCvAvgComp faces in facesDected[0])
            {
                //daca a fost detectata vreo fata incrementeaza j
                j = j + 1;
                //copiere frameuri in variabila results
                //converitre frameuri la nuante de gri si redimensionarea lor la 100x100 pixeli
                results = currentFrame.Copy(faces.rect).Convert<Gray, Byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //desenare dreptungi pe fetele detectate
                currentFrame.Draw(faces.rect, new Bgr(Color.Green), 2);

                if (trainingFaces.ToArray().Length != 0)
                {
                    //folosesc termcriteria pentru fiecare imagine salvata in baza de date
                    MCvTermCriteria termCrit = new MCvTermCriteria(CountPersons, 0.001);
                    //initializez clasa EigenObjectRecognizer
                    EigenFaceRecognizerEngine recognizeFace = new EigenFaceRecognizerEngine(
                        trainingFaces.ToArray(),
                        NamesOfPersons.ToArray(),
                        //1000,
                        1500,
                       //1000,
                        ref termCrit);
                    //detectare persoana 
                    
                    NameOfDetectedPerson = recognizeFace.Recognize(results);
                    //GetDetectedFace();
                    if (NameOfDetectedPerson.Contains("Necunoscut"))
                    {
                        
                        LoopDataBaseForward();

                    }
                    GetDetectedFace();



                    //afisare nume persoana
                    //initializare font pentru afisarea numelui persoanei detectate
                    currentFrame.Draw(NameOfDetectedPerson, ref font, new Point(faces.rect.X - 2, faces.rect.Y - 2), new Bgr(Color.LightGreen));
                    
                }

                NamePersons[j-1] = NameOfDetectedPerson;
                NamePersons.Add("");
            }

            //vizualizarea frameurilor capturate in imagebox
            imageBoxRecognizer.Image = currentFrame;
            
            //verificare daca imaginiile din baza de date sunt incarcate,
            //sa existe cel putin o imagine in baza de date
            //astfel programul poate sa inceapa recunoasterea
            //LoadFacesFromDatabase realizeaza acest lucru



        }
        //functia returneaza pozitia numelui persoanei detectate in array
        //si afiseaza intr-un imageBox poza cu persoana respectiva
        public void GetDetectedFace()
        {
            string readFille = File.ReadAllText(Application.StartupPath + "/DataBase/PersonsNames.txt");
            string[] theName = readFille.Split('%');
            int nr;
            int position = -1;
            String Faces;
            Image<Gray, byte> getPictureOfDetectedPerson = null;
            nr = Convert.ToInt16(theName[0]);
            for (int i = 1; i < nr + 1; i++)
            {
                if (theName[i] == NameOfDetectedPerson)
                {
                    position = i;
                    //doar pentru testare
                    //button1.Text = i.ToString();
                    //poza cu persoana detectata este selectata din baza de date si afisata pe un imageBox
                    Faces = "face" + position + ".bmp";
                    getPictureOfDetectedPerson = new Image<Gray, byte>(Application.StartupPath + "/DataBase/" + Faces);
                    imageBox1.Image = getPictureOfDetectedPerson;
                    
                }
            }

        }

        int loopDataBase = 1;
        public void LoopDataBaseForward() {
                //string PersonInfo = File.ReadAllText(Application.StartupPath + "/DataBase/PersonsNames.txt");
                //string[] Labels = PersonInfo.Split('%');
                //int MaxItemsArray = Convert.ToInt16(Labels[0]);
                String caleImagine = "face" + loopDataBase + ".bmp";
                Image<Gray, byte> imagineActuala = new Image<Gray, byte>(Application.StartupPath + "/DataBase/" + caleImagine);
                imageBox1.Image = imagineActuala;
                loopDataBase = loopDataBase + 1;
                //Thread.Sleep(2000);
                if (loopDataBase > NumLabels)
                {
                    loopDataBase = 1;
                }

        }

        
        public void LoadFacesFromDataBase()
        {
            try
            {
                string PersonInfo = File.ReadAllText(Application.StartupPath + "/DataBase/PersonsNames.txt");
                string[] Labels = PersonInfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);//numarul total e fete
                CountPersons = NumLabels;//adaugare imagine in baza de date pe langa cele existente
                TotalNrPersonsInDataBase.total = NumLabels;
                string LoadFaces;
                //j for trainedfaces
                for (int j = 1; j < NumLabels +1; j++)
                {
                    LoadFaces = "face" + j + ".bmp";
                    trainingFaces.Add(new Image<Gray, byte>(Application.StartupPath + "/DataBase/" + LoadFaces));
                    NamesOfPersons.Add(Labels[j]);
                }
            }

            catch
            {
                MessageBox.Show("Baza de date nu a putut fi incarcata, sau baza de data este goala", "Baza de date", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // functiile pentru conectarea la arduino prin cablu
        /*
        void getAvailableComPorts()
        {
            COMArduinoPorts = SerialPort.GetPortNames();
           
        }

        private void SelectarePortArduino()
        {
            getAvailableComPorts();

            foreach (string port in COMArduinoPorts)
            {
                ArduinoPort.Items.Add(port);
                Console.WriteLine(port);
                if (COMArduinoPorts[0] != null)
                {
                    ArduinoPort.SelectedItem = COMArduinoPorts[0];
                }
            }
        }

        private void ConectareLaArduino()
        {
            isConnectedToArduino = true;
            string selectedPort = ArduinoPort.GetItemText(ArduinoPort.SelectedItem);
            try
            {
                port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
                port.Open();
                //port.Write("#STAR\n");
                btnConnectToArduino.Text = "Disconnect";
                MessageBox.Show("Conectat la arduino prin portul: " + selectedPort, "Mesaj Informativ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch
            {
                MessageBox.Show("Conectarea nu s-a putut efectua.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isConnectedToArduino = false;
            }
        }

        private void DeconectareDelaArduino()
        {
            try
            {
                isConnectedToArduino = false;
                //port.Write("#STOP\n");
                port.Close();
                btnConnectToArduino.Text = "Connect";
                MessageBox.Show("Deconectat de la arduino", "Mesaj Informativ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch
            {

            }
        }

            private void btnConnectToArduino_Click(object sender, EventArgs e)
            {
            if (!isConnectedToArduino)
            {
                ConectareLaArduino();
            }
            else
            {
                DeconectareDelaArduino();
            }
        }

        */
        //testare trimitere mail(functioneaza perfect)

        
        private void button1_Click(object sender, EventArgs e)
        {
            if (NameOfDetectedPerson.Contains("Necunoscut"))
            {
                String fileName = ".\\PersoaneNecunoscute\\Image_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".jpg";//Save the filename first on
                imageBoxRecognizer.Image.Save(fileName);
                TrimiteMail.TrimitereEmail("moalebogdan147@gmail.com", "Alerta", "Cineva neautorizat a incercat sa porneasca sistemul in data de: " + DateTime.Now, fileName);
            }

            else
            {
                MessageBox.Show("OK", "Mesaj Informativ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
            // port.Write("A");
        }


        /*
        private void button2_Click(object sender, EventArgs e)
        {
            port.Write("2");
            port.ReadTimeout = 3500; 
            string data = port.ReadLine();
           
            MessageBox.Show(data, "Mesaj Informativ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        */



        public double test = 1200;
        public void trackBarTreshold_Scroll_1(object sender, EventArgs e)
        {
            //eigenFaceClass._eigenDistanceThreshold = Convert.ToDouble(trackBarTreshold.Value);
            //Console.WriteLine(eigenFaceClass._eigenDistanceThreshold);
            //test = Convert.ToDouble(trackBarTreshold.Value);
            //Console.WriteLine(test);

        }

        private void Recognizer_Load(object sender, EventArgs e)
        {
            timer1.Start();
            textBoxTimp.Text = DateTime.Now.ToLongTimeString();
            textBoxData.Text = DateTime.Now.ToString("MM/dd/yyyy");
            incarcareCaleDateBaseAngajati();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBoxTimp.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        
        private void btnSosire_Click(object sender, EventArgs e)
        {
            if (NameOfDetectedPerson.Contains("Necunoscut")){
                String fileName = ".\\PersoaneNecunoscute\\Image_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".jpg";//Save the filename first on
                imageBoxRecognizer.Image.Save(fileName);
                TrimiteMail.TrimitereEmail(SetEmail.maillTo, "Alerta", "Cineva neautorizat a fost detectat in data de: " + DateTime.Now, fileName);
            }
            else
            {
                Excel excel = new Excel(caleBazaDateAngajati, 1);
                excel.searchForPersonWhoArrive(NameOfDetectedPerson, 1, 0, textBoxData.Text, textBoxTimp.Text);
                excel.Save();
                excel.Close();
                MessageBox.Show("Angajatul:" + NameOfDetectedPerson + " a sosit la ora:" + DateTime.Now.ToShortTimeString());
                //inchidere procese excel
                foreach (var process in System.Diagnostics.Process.GetProcessesByName("EXCEL"))
                {
                    process.Kill();
                }  
            }
            
        }

        private void btnPlecare_Click(object sender, EventArgs e)
        {
            if (NameOfDetectedPerson.Contains("Necunoscut"))
            {
                String fileName = ".\\PersoaneNecunoscute\\Image_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".jpg";//Save the filename first on
                imageBoxRecognizer.Image.Save(fileName);
                TrimiteMail.TrimitereEmail(SetEmail.maillTo, "Alerta", "Cineva neautorizat a fost detectat in data de: " + DateTime.Now, fileName);
            }

            else
            {
                Excel excel = new Excel(caleBazaDateAngajati, 1);
                excel.searchForPersonWhoLeave(NameOfDetectedPerson, 1, 0, textBoxData.Text, textBoxTimp.Text);
                excel.calculareOreLucrate(NameOfDetectedPerson,1,0);
                excel.Save();
                excel.Close();
                //inchidere procese excel
                foreach (var process in System.Diagnostics.Process.GetProcessesByName("EXCEL"))
                {
                    process.Kill();
                }
            }
        }

        public void dataBaseAngajati()
        {
            OpenFileDialog bazaDateAngajati = new OpenFileDialog();
            if (bazaDateAngajati.ShowDialog() == DialogResult.OK)
            {
                caleBazaDateAngajati = bazaDateAngajati.FileName;
                textBoxBrowse.Text = caleBazaDateAngajati;
            }


        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            dataBaseAngajati();
            creareTabelDataBase();
        }

        public void incarcareCaleDateBaseAngajati()
        {
            textBoxBrowse.Text = Properties.Settings.Default.txtPath;
            
        }

        public void salvareCaleDatabesAngajati()
        {
            Properties.Settings.Default.txtPath = textBoxBrowse.Text;
            Properties.Settings.Default.Save();
        }

        private void Recognizer_FormClosed(object sender, FormClosedEventArgs e)
        {
            salvareCaleDatabesAngajati();
        }

        public void creareTabelDataBase()
        {
            Excel excel = new Excel(caleBazaDateAngajati, 1);
            excel.WriteToCell(0, 0, "Nume");
            excel.WriteToCell(0, 1, "Data");
            excel.WriteToCell(0, 2, "Ora Sosire");
            excel.WriteToCell(0, 3, "Ora plecare");
            excel.WriteToCell(0, 4, "Ore lucrate");

            string readFille = File.ReadAllText(Application.StartupPath + "/DataBase/PersonsNames.txt");
            string[] theName = readFille.Split('%');
            int nr;
            nr = Convert.ToInt16(theName[0]);
            for (int i = 1; i < nr + 1; i++)
            {
                excel.WriteToCell(i, 0, theName[i]);
            }

            excel.Save();
            excel.Close();
            //inchidere procese excel
            foreach (var process in System.Diagnostics.Process.GetProcessesByName("EXCEL"))
            {
                process.Kill();
            }
        }

        public void saveDataBaseToExcel()
        {
            Excel excel = new Excel(caleBazaDateAngajati, 1);

            string readFille = File.ReadAllText(Application.StartupPath + "/DataBase/PersonsNames.txt");
            string[] theName = readFille.Split('%');
            int nr;
            nr = Convert.ToInt16(theName[0]);
            for (int i = 1; i < nr + 1; i++)
            {
                excel.WriteToCell(i, 0, theName[i]);
            }

            excel.Save();
            excel.Close();
            //inchidere procese excel
            foreach (var process in System.Diagnostics.Process.GetProcessesByName("EXCEL"))
            {
                process.Kill();
            }
        }

        private void GenerareRaport_Click(object sender, EventArgs e)
        {
            string path = textBoxBrowse.Text;
            string removeLastFourCharFromPath=path.Substring(0, path.Length - 5);
            string finalPath = removeLastFourCharFromPath + "_" + DateTime.Now.ToString("MM.dd.yyyy") + ".xlsx";

            Excel excel = new Excel(path, 1);
            //excel.Save();
            excel.SaveAs(finalPath);
            excel.Close();
        }

        public void deleteOld()
        {
            Excel excel = new Excel(caleBazaDateAngajati, 1);
            excel.clear(1, 2);
            excel.Save();
            excel.Close();
            //inchidere procese excel
            foreach (var process in System.Diagnostics.Process.GetProcessesByName("EXCEL"))
            {
                process.Kill();
            }

        }
        
        int trackValue = 0;
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackValue = this.trackBar.Value;
            TresholdValue.SetTresholdVal = trackValue;
            int valTresh = trackValue / 10;
            treshValLabel.Text = valTresh.ToString();
            //MessageBox.Show(trackValue.ToString());
        }

        private void showTresholdForm()
        {
            TresholdForm th = new TresholdForm();
            th.Show();
        }
    }
}
