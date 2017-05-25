using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using WebSite.Backend.Interfaces;

namespace WebSite.Backend.Manager
{
    public class MailManager
    {
        private readonly IMailingConfigurator _mailConfigurator;

        public MailManager(IMailingConfigurator mailConfigurator)
        {
            _mailConfigurator = mailConfigurator;
        }

        private IMailingConfigurator MailConfigurator
        {
            get { return _mailConfigurator; }
        }

        public string SendMail(Stream htmlFlow, string mailSubject, string destMail)
        {
            string returnedMessage = "OK";

            MailMessage mailMessage = new MailMessage();
            
            mailMessage.IsBodyHtml = true;

            using (var streamReader = new StreamReader(htmlFlow))
            {
                mailMessage.Body = streamReader.ReadToEnd();
            }

            mailMessage.From = new MailAddress(MailConfigurator.GetSenderMail(), MailConfigurator.GetSenderName(), Encoding.UTF8);
            mailMessage.To.Add(new MailAddress(destMail));
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.Subject = mailSubject;
            mailMessage.SubjectEncoding = Encoding.UTF8;

            try
            {
                SmtpClient smtpClient = new SmtpClient(MailConfigurator.GetHost(),MailConfigurator.GetPort());
                smtpClient.Credentials = new NetworkCredential(MailConfigurator.GetSenderMail(), MailConfigurator.GetSenderPassword());
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);
            }
            catch (Exception e)
            {
                returnedMessage = e.Message;
            }
            finally
            {
                mailMessage.Dispose();
            }

            return returnedMessage;
        }

        public string SendMail()
        {
            string sentMailStatus = "OK";
            string destAddress = ConfigurationManager.AppSettings["DestAddress"];
            string senderAddress = ConfigurationManager.AppSettings["SenderAddress"];
            string senderPwd = ConfigurationManager.AppSettings["SenderPwd"];
            string smtpHost = ConfigurationManager.AppSettings["SmtpHost"]; ;
            int smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
            
            //SmtpClient client = new SmtpClient(smtpHost, smtpPort);
            SmtpClient client = new SmtpClient(smtpHost);

            // Include some non-ASCII characters in from.
            MailAddress fromMailAddress = new MailAddress(senderAddress,
                string.Format("DEMS{0}Samir", (char) 0xD8), Encoding.UTF8);
            MailAddress toMailAddress = new MailAddress(destAddress);
            
            var mailMessage = new MailMessage(fromMailAddress, toMailAddress);
            mailMessage.Body = "This is a test e-mail message sent by an application. ";

            // Include some non-ASCII characters in body and subject.
            string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.Subject = "test message 1" + someArrows;
            mailMessage.SubjectEncoding = Encoding.UTF8;

            client.Credentials = new NetworkCredential(senderAddress, "yourEmailPassword");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;

            try
            {
                client.Send(mailMessage);
            }
            catch (Exception e)
            {
                sentMailStatus = e.Message;
            }
            finally
            {
                mailMessage.Dispose();
            }

            return sentMailStatus;
        }
    }
}
