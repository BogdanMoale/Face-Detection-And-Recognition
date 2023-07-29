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


namespace FaceRecognition
{
    
    public partial class TrainingModule : Form
    {
        Capture captureImage;
        Image<Bgr, byte> currentFrame;
        //initializare haarcascade pentru detectarea fetei
        HaarCascade faceDetection;
        Image<Gray, byte> imageToGrayScale = null;
        Image<Gray, byte> results = null;
        Image<Gray, byte> DetectedFace = null;
        int j = 0; // variabila pentru stocarea numarului de fete
        //initializare liste pentru stocarea numelui si a fetei
        List<Image<Gray, byte>> imageToDataBase = new List<Image<Gray, byte>>();//fata
        List<string> NamesOfPersons = new List<string>();//nume
        int NumLabels;
        int CountPersons = 0;
        private bool captureInProgress;


        public TrainingModule()
        {
            //incarcarea fisierului haarcascade
            faceDetection = new HaarCascade("haarcascade-frontalface-default.xml");

            InitializeComponent();
            LoadFacesFromDataBase();
            DezactivateCommands();
            
        }

        public void LoadFacesFromDataBase()
        {
            try
            {
                string PersonInfo = File.ReadAllText(Application.StartupPath + "/DataBase/PersonsNames.txt");
                string[] Labels = PersonInfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);//numarul total e fete
                CountPersons = NumLabels;//adaugare imagine in baza de date pe langa cele existente

                string LoadFaces;
                //j for trainedfaces
                for (int j = 1; j < NumLabels+1; j++)
                {
                    LoadFaces = "face" + j + ".bmp";
                    imageToDataBase.Add(new Image<Gray, byte>(Application.StartupPath + "/DataBase/" + LoadFaces));
                    NamesOfPersons.Add(Labels[j]);
                }
            }

            catch
            {
                MessageBox.Show("Data base was not loaded, or data base it's empty", "Data Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
           

        }

        //functie modificata pentru optiunea antrenare baza de date

        public void LoadFacesFromDataBaseForTraining()
        {
            try
            {
                string PersonInfo = File.ReadAllText(Application.StartupPath + "/DataBase/PersonsNames.txt");
                string[] Labels = PersonInfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);//numarul total e fete
                CountPersons = NumLabels;//adaugare imagine in baza de date pe langa cele existente

                string LoadFaces;
                //j for trainedfaces
                for (int j = 1; j < NumLabels + 1; j++)
                {
                    LoadFaces = "face" + j + ".bmp";
                    imageToDataBase.Add(new Image<Gray, byte>(Application.StartupPath + "/DataBase/" + LoadFaces));
                    NamesOfPersons.Add(Labels[j]);

                    AfisareInRichTextBox(Labels[j]); 
                }

                
            }

            catch
            {
                MessageBox.Show("Data base was not loaded, or data base it's empty", "Data Base", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        public void AfisareInRichTextBox(string output)
        {
            if (!string.IsNullOrWhiteSpace(richTextBoxAntrenare.Text))
            {
                richTextBoxAntrenare.AppendText("\r\n" + output);
            }
            else
            {
                richTextBoxAntrenare.AppendText(output);
            }
            richTextBoxAntrenare.ScrollToCaret();
        }

        public void ActivateCommands()
        {
            
           
            textBoxName.Visible = true;
            label1.Visible = true;
        }


        public void DezactivateCommands()
        {
           
           
            textBoxName.Visible = false;
            label1.Visible = false;
           
        }

        
        //initializarea evenimentului CurrentFrameGrabber
        private void CurrentFrameGrabber(object sender, EventArgs e)
        {
            currentFrame = captureImage.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            //convertirea imaginii in nuante de gri(grayscale)
            imageToGrayScale = currentFrame.Convert<Gray, Byte>();
            //detectarea fetei
            MCvAvgComp[][] facesDected = imageToGrayScale.DetectHaarCascade(
                faceDetection, 
                1.2, 
                10, 
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
            }
           
            //vizualizarea frameurilor capturate in imagebox
            imageBox.Image = currentFrame;
        }

       
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            StartScreen start = new StartScreen();
            start.Show();
            this.Hide();
        }

        public void ReleaseData()
        {
            if (captureImage != null)
            captureImage.Dispose();
            
        }

        public void StartCapture()
        {
            captureInProgress = true;
            if (captureImage == null)
            {
                //daca captureImage este null, initializeaza captureImage
                try
                {
                    captureImage = new Capture();
                    captureImage.QueryFrame();
                   
                }

                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
                Application.Idle += CurrentFrameGrabber;
            }
        }

        public void StopCaptureForTraining()
        {
           
            if (captureInProgress)
            {
                Application.Idle -= CurrentFrameGrabber;
                captureInProgress = true;
                ReleaseData();
            }
        }

        public void Capture()
        {
            if (captureImage == null)
            {
                try {
                    captureImage = new Capture();
                    captureImage.QueryFrame();
                    
                }

                catch(NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }

            }

            if(captureImage != null)
            {
                if (captureInProgress)
                {
                    pornireCameraToolStripMenuItem.Text = "Pornire Capturare";
                    Application.Idle -= CurrentFrameGrabber;
                    //ReleaseData();
                }
                else
                {
                    pornireCameraToolStripMenuItem.Text = "Oprire Capturare";
                    Application.Idle += CurrentFrameGrabber;
                    
                }
                captureInProgress = !captureInProgress;
            }
        }

        private void pornireCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //captureImage = new Capture();
            //initializare capturare imagine
            //captureImage.QueryFrame();
            //incepere capturare imagine
            //Application.Idle += new EventHandler(CurrentFrameGrabber);
            Capture();
            ActivateCommands();
            
            
        }

        private void capturareFataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //iau frameul curent si il stochez in variabila DetectedFace
                DetectedFace = results.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //arata fata detectata in imagebox
                //aici pot sa fac o egalizare de histograma(optional)
                imageboxForDetectedFace.Image = DetectedFace;
            }

            catch
            {
                MessageBox.Show("Camera error", "Camera Output", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void antrenareFataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CountPersons = CountPersons + 1;
            //in folderul DataBase se salveaza imaginea capturata a persoanei
            //in fisierul PersonsName.txt se salveaza numele persoanei
            //adaugare imagine in lista imageToDataBase
            imageToDataBase.Add(DetectedFace);
            //adaugare nume persoana in lista NamesOfPersons
            NamesOfPersons.Add(textBoxName.Text);
            //adaugare nume in fisierul PersonsName.txt
            File.WriteAllText(Application.StartupPath + "/DataBase/PersonsNames.txt", imageToDataBase.ToArray().Length.ToString() + "%");
            //salvare imagine 
            //i numarul de fete
            for (int i = 1; i < imageToDataBase.ToArray().Length + 1; i++)
            {
                imageToDataBase.ToArray()[i - 1].Save(Application.StartupPath + "/DataBase/face" + i + ".bmp");//salvare imagine
                File.AppendAllText(Application.StartupPath + "/DataBase/PersonsNames.txt", NamesOfPersons.ToArray()[i - 1] + "%");
            }
            //salvare nume persoana in database
            /*
            Excel excel = new Excel(@"C:\Users\Bogdi\Desktop\FaceRecognition\FaceRecognition\bin\Debug\Angajati.xlsx", 1);
            excel.saveNewPerson(textBoxName.Text, 1, 0);
            excel.Save();
            excel.Close();
            //inchidere procese excel
            foreach (var process in System.Diagnostics.Process.GetProcessesByName("EXCEL"))
            {
                process.Kill();
            }
            */
            MessageBox.Show("Persoana a fost adugata in baza de date", "Baza date", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void recunoastereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Recognizer = new Recognizer();
            Recognizer.Closed += (s, args) => this.Close();
            Recognizer.Show();
            StopCaptureForTraining();

        }

        private void oprireCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopCaptureForTraining();
        }

        int nrIteratii = 0;

        private void antrenareBazaDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFacesFromDataBaseForTraining();
            nrIteratii = nrIteratii + 1;
            MessageBox.Show("Baza de date a fost incarcata si antrenata cu scucces!" + "Nr iteratii: " + nrIteratii, "Baza date", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
