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
    public partial class TresholdForm : Form
    {
        public TresholdForm()
        {
            InitializeComponent();
        }

        int trackValue = 0;
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            trackValue = this.trackBar.Value;
            TresholdValue.SetTresholdVal = trackValue;
            int valTresh = trackValue / 10;
            labelTreshVal.Text = valTresh.ToString();
        }
    }
}
