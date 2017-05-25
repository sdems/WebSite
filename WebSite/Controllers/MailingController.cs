using System;
using System.Configuration;
using System.IO;
using System.Web.Mvc;
using WebSite.Backend.Interfaces;
using WebSite.Backend.Manager;

namespace WebSite.Controllers
{
    public class MailingController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMail()
        {
            //string htmlFilePath = ConfigurationManager.AppSettings["HtmlFilePath"];
            string sentMailMessage;
            string htmlFilePath = Server.MapPath(@"/MailingElements/PleaseRegisterMail.html");
            MailManager mailManager = new MailManager(new GmailConfurator());

            using (var fileStream = new FileStream(htmlFilePath,FileMode.Open))
            {
                sentMailMessage = mailManager.SendMail(fileStream, "this is the mail subject", "samir.dems@outlook.com");
            }

            return Content(sentMailMessage);
        }
    }

    public class GmailConfurator : IMailingConfigurator
    {
        public string GetHost()
        {
            return ConfigurationManager.AppSettings["SmtpHost"];
        }

        public string GetSenderName()
        {
            return ConfigurationManager.AppSettings["SenderName"];
        }

        public string GetSenderMail()
        {
            return ConfigurationManager.AppSettings["SenderAddress"];
        }

        public string GetSenderPassword()
        {
            return ConfigurationManager.AppSettings["SenderPwd"];
        }

        public int GetPort()
        {
            return int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
        }
    }
}
