using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace FaceRecognition
{
    class TrimiteMail
    {
        public static void TrimitereEmail(string persoanaLaCareSeTrimiteMail, string SubiectMail, string corpEmail, string caleAtasament)
        {
            //string persoanaCareTrimiteMail = "aplicatie.recunoastere.fata.@gmail.com";
            string persoanaCareTrimiteMail = SetEmail.mailFrom;
            //string parola = "b1o2g3b1o2g3";
            string parola = SetEmail.maillPassword;
            //string adresaSmtp = "smtp.gmail.com";
            string adresaSmtp = SetEmail.maillSmtpAdress;
            //int port = 587;
            int port = Int32.Parse(SetEmail.maillPort);
            bool PornireSSL = true;

            using (MailMessage Mail=new MailMessage())
            {
                Mail.From = new MailAddress(persoanaCareTrimiteMail);
                Mail.To.Add(persoanaLaCareSeTrimiteMail);
                Mail.Subject = SubiectMail;
                Mail.Body = corpEmail;
                Mail.IsBodyHtml = true;

                if (caleAtasament.Length > 2)
                {
                    Mail.Attachments.Add(new Attachment(caleAtasament));
                }

                using (SmtpClient _clientsmtp = new SmtpClient(adresaSmtp, port))
                {
                    _clientsmtp.Credentials = new NetworkCredential(persoanaCareTrimiteMail, parola);
                    _clientsmtp.EnableSsl = PornireSSL;
                    _clientsmtp.Send(Mail);
                }
            }
        }
    }
}
