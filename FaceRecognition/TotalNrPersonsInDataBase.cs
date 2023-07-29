using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition
{
    class TotalNrPersonsInDataBase
    {
        static int totalPersons;

        public static int total
        {
            get
            {
                return totalPersons;
            }
 
            set
            {
                totalPersons = value;
            }
        }
    }
}
