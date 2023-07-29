using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition
{
    class TresholdValue
    {
        static int tresholdVal;

        public static int SetTresholdVal
        {
            get
            {
                return tresholdVal;
            }
            set
            {
                tresholdVal = value;
            }
        }

    }
}
