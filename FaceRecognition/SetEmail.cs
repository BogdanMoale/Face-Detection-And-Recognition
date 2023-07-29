using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognition
{
    class SetEmail
    {
        static string from, passw, to, smtpAdress, port;

        public static string mailFrom
        {
            get
            {
                return from;
            }
            set
            {
                from = value;
            }
        }


        public static string maillPassword
        {
            get
            {
                return passw;
            }
            set
            {
                passw = value;
            }
        }


        public static string maillTo
        {
            get
            {
                return to;
            }
            set
            {
                to = value;
            }
        }

        public static string maillSmtpAdress
        {
            get
            {
                return smtpAdress;
            }
            set
            {
                smtpAdress = value;
            }
        }

        public static string maillPort
        {
            get
            {
                return port;
            }
            set
            {
                port = value;
            }
        }
    }
}
