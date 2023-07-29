using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace FaceRecognition
{
    class Excel
    {
        string path = "";
        _Application excel = new _Excel.Application();
        public Workbook wb;
        public Worksheet ws;

        public Excel(string path, int sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = excel.Worksheets[sheet];
        }

        public string ReadCell(int i, int j)
        {
            i++;
            j++;
            if (ws.Cells[i, j].Value2 != null)
            {
                return ws.Cells[i, j].Value2;
            }

            else
            {
                return " ";
            }
        }

        public void WriteToCell(int i, int j, string s)
        {
            i++;
            j++;
            ws.Cells[i, j].Value2 = s;
        }

        public void Save()
        {
            wb.Save();

        }

        public void SaveAs(string path)
        {
            wb.SaveAs(path);
        }

        public void Close()
        {
            wb.Close();
        }

        public void searchForPersonWhoArrive(string name, int i, int j, string data, string ora)
        {
            i++;
            j++;
            int nrAngajati = 0;
            for (nrAngajati = 1; nrAngajati <= TotalNrPersonsInDataBase.total; nrAngajati++)
            {
                if (ws.Cells[i, j].Value2 == name)
                {
                    ws.Cells[i, j + 1].Value2 = data;
                    ws.Cells[i, j + 2].Value2 = ora;
                }
                i++;
            }
        }

        public void searchForPersonWhoLeave(string name, int i, int j, string data, string ora)
        {
            i++;
            j++;
            int nrAngajati = 0;
            for (nrAngajati = 0; nrAngajati<=TotalNrPersonsInDataBase.total; nrAngajati++)
            {
                if (ws.Cells[i, j].Value2 == name)
                {
                    ws.Cells[i, j + 1].Value2 = data;
                    ws.Cells[i, j + 3].Value2 = ora;
                }
                i++;
            }
        }

        public void saveNewPerson(string name, int i, int j)
        {
            i++;
            j++;
            int nrAngajati = 0;
            for (nrAngajati = 0; nrAngajati <= TotalNrPersonsInDataBase.total; nrAngajati++)
            {
                if (ws.Cells[i, j].Value2!=null)
                {
                    i++;
                }
                else
                { 
                    ws.Cells[i, j].Value2 = name;
                    nrAngajati = 100;
                }
                
            }
        }

        public void calculareOreLucrate(string name,int i,int j)
        {
            i++;
            j++;

            int nrAngajati = 0;
            for (nrAngajati = 0; nrAngajati <= TotalNrPersonsInDataBase.total; nrAngajati++)
            { 
                string totalFromula = String.Concat("=","D", i, "-", "C", i);
                if (ws.Cells[i, j].Value2 == name)
                {
                    ws.Cells[i, j+4].Formula = totalFromula;
                }
                i++;
            }
        }

        public void clear(int i, int j)
        {
            i++;
            j++;
            System.Windows.Forms.MessageBox.Show(ws.Cells[i, j].Value2);
            int k = 0;
            //for (k = 0; k <= TotalNrPersonsInDataBase.total; k++)
            //{
                //System.Windows.Forms.MessageBox.Show(ws.Cells[i, j].Value2);
            //}
        }

    }
}

