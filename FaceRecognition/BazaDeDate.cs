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
    public partial class BazaDeDate : Form
    {
        int MaxItemsArray;
        int CountPersons = 0;
        List<Image<Gray, byte>> imageToDataBase = new List<Image<Gray, byte>>();
        List<string> NamesOfPersons = new List<string>();
        int j = 0;
        String caleImagine;
        Image<Gray, byte> imagineActuala = null;
        string PersonInfo;
        string[] Labels;
       





        public BazaDeDate()
        {
            InitializeComponent();
            IncarcareBazaDate();
            IncarcarePrimaImagine();
          
        }

        public void IncarcarePrimaImagine()
        {
            j = 1;
            caleImagine = "face" + j + ".bmp";
            imagineActuala = new Image<Gray, byte>(Application.StartupPath + "/DataBase/" + caleImagine);
            imageBoxDataBase.Image = imagineActuala;
            textBoxNumePersoana.Text = Labels[j];
           
        }
        
        public void IncarcareBazaDate()
        {
            try
            {
                PersonInfo = File.ReadAllText(Application.StartupPath + "/DataBase/PersonsNames.txt");
                Labels = PersonInfo.Split('%');
                MaxItemsArray = Convert.ToInt16(Labels[0]);
                CountPersons = MaxItemsArray;

                string LoadFaces;
               
                for (j = 1; j < MaxItemsArray + 1; j++)
                {
                    LoadFaces = "face" + j + ".bmp";
                    imageToDataBase.Add(new Image<Gray, byte>(Application.StartupPath + "/DataBase/" + LoadFaces));
                    NamesOfPersons.Add(Labels[j]);
                    
                }
            }

            catch
            {
                MessageBox.Show("Eroare", "Baza de date", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
       
        private void ImagineInainte_Click(object sender, EventArgs e)
        {

            j = j + 1;
            caleImagine ="face" + j + ".bmp";
            imagineActuala = new Image<Gray, byte>(Application.StartupPath + "/DataBase/" + caleImagine);
            imageBoxDataBase.Image = imagineActuala;
            textBoxNumePersoana.Text = Labels[j];
            Console.WriteLine(j);
            Console.WriteLine(MaxItemsArray);
            Console.WriteLine(Labels[j]);
            if (j >= MaxItemsArray)
            {
                btnImagineInainte.Enabled = false;
            }
            btnImagineInapoi.Enabled = true;

        }

        private void ImagineInapoi_Click(object sender, EventArgs e)
        {
            
            j = j - 1;
            caleImagine = "face" + j + ".bmp";
            imagineActuala = new Image<Gray, byte>(Application.StartupPath + "/DataBase/" + caleImagine);
            imageBoxDataBase.Image = imagineActuala;
            textBoxNumePersoana.Text = Labels[j];
            Console.WriteLine(j);
            Console.WriteLine(MaxItemsArray);
            Console.WriteLine(Labels[j]);
            if (j ==1)
            {
                btnImagineInapoi.Enabled = false;
            }

            btnImagineInainte.Enabled = true;

        }

       public void updatePersonName()
        {
            try
            {
                PersonInfo = File.ReadAllText(Application.StartupPath + "/DataBase/PersonsNames.txt");
                Labels = PersonInfo.Split('%');
                MaxItemsArray = Convert.ToInt16(Labels[0]);
                CountPersons = MaxItemsArray;



                for (int j = 1; j < MaxItemsArray + 1; j++)
                {

                    NamesOfPersons.Add(Labels[j]);

                }
            }

            catch
            {
                MessageBox.Show("Eroare", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnActualizareNume_Click(object sender, EventArgs e)
        {
            
            PersonInfo = File.ReadAllText(Application.StartupPath + "/DataBase/PersonsNames.txt");
            //Labels = PersonInfo.Split('%');
            PersonInfo = PersonInfo.Replace(Labels[j], textBoxNumePersoana.Text);
            File.WriteAllText(Application.StartupPath + "/DataBase/PersonsNames.txt", PersonInfo);
            updatePersonName();
            textBoxNumePersoana.Text = textBoxNumePersoana.Text;
            MessageBox.Show("Numele persoanei a fost actualizat", "Actualizare nume", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
