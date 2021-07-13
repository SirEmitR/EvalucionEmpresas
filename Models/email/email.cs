using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EvaluacionEmpresa.Models.email
{
    public class email
    {
        public void Carta()
        {
            //try
            //{
            //    SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
            //    client.Port = 587;
            //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //    client.UseDefaultCredentials = false;
            //    System.Net.NetworkCredential credential = new System.Net.NetworkCredential("jesuse.reyes@edu.uag.mx", "Guillermina")
            //}
            //catch
            //{
            //    throw;
            //}
            string emailOrigen = "emit3reyes@gmail.com";
            string emailDestino = "jesuse.reyes@edu.uag.mx";
            //string emailDestino = "laflorquemarchitoelolvido15@gmail.com";
            string password = "guillermina23";
            MailMessage mailMessage = new MailMessage(emailOrigen, emailDestino, "Carta de retroalimentacion UAG", "texto");

            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.EnableSsl = true; //Seguro
            smtpClient.UseDefaultCredentials = false;
            //smtpClient.Host = "smtp.gmail.com"
            smtpClient.Port= 587;
            smtpClient.Credentials = new System.Net.NetworkCredential(emailOrigen, password);
            smtpClient.Send(mailMessage);
            smtpClient.Dispose();
        }
    }
}
