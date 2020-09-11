using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Text;


namespace Portfolio.Utilities
{
    public class SendEmail
    {
        public void Send(string senderEMailAddress, string senderPassword, string ReceiverSmtp, int ReceiverPort, string toEmailAddress, string Subject, string EmailBody, string cc)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient(ReceiverSmtp, ReceiverPort);
                smtpClient.EnableSsl = true;
                smtpClient.Timeout = 100000;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(senderEMailAddress, senderPassword);
                MailMessage mailMessage = new MailMessage(senderEMailAddress, toEmailAddress);
                mailMessage.Subject = Subject;
                mailMessage.Body = EmailBody;
                MailAddress ccmail = new MailAddress(cc);
                mailMessage.CC.Add(ccmail);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;
                smtpClient.Send(mailMessage);

            }
            catch (Exception ex)
            {


            }
        }

    }
}