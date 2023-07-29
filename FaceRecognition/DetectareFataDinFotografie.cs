using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System.IO;

namespace FaceRecognition
{
    public partial class DetectareFataDinFotografie : Form
    {

        
        Image<Gray, byte> imageToGrayScale = null;
        Image<Gray, byte> results = null;
        HaarCascade faceDetection;
        int j = 0; // variabila pentru stocarea numarului de fete
        Image<Gray, byte> DetectedFace = null;
        Image<Bgr, Byte> currentFrame = null;

        List<string> NamesOfPersons = new List<string>();//nume
        int NumLabels;
        int CountPersons = 0;
        List<Image<Gray, byte>> imageToDataBase = new List<Image<Gray, byte>>();//fata



        public DetectareFataDinFotografie()
        {
            faceDetection = new HaarCascade("haarcascade-frontalface-default.xml");
            InitializeComponent();
            LoadFacesFromDataBase();
            LoadImage();
            DetectFace();
        }
    

        private void btnCapture_Click(object sender, EventArgs e)
        {
            //iau frameul curent si il stochez in variabila DetectedFace
            DetectedFace = results.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            //arata fata detectata in imagebox
            imageBox1.Image = DetectedFace;
        }
   
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    currentFrame = new Image<Bgr, byte>(ofd.FileName);
                    imageBox.Image = currentFrame;
                    DetectFace();
                }
            }

            catch
            {

            } 
        }

        public void LoadImage()
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    currentFrame = new Image<Bgr, byte>(ofd.FileName);
                    imageBox.Image = currentFrame;
                }
            }

            catch
            {

            }
        }

        public void DetectFace()
        {
            //Image<Bgr, Byte> currentFrame = new Image<Bgr, byte>("Ramona.jpg");
            currentFrame.Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
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
                for (int j = 1; j < NumLabels + 1; j++)
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

        public void AddPersonInDataBase()
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
            MessageBox.Show("Persoana a fost adugata in baza de date", "Baza date", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            AddPersonInDataBase();
        }
    }
}
