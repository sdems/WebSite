using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebSite.Backend.Interfaces;
using WebSite.Backend.Manager;

namespace WebSite.Tests.WebSite.Backend.Manager
{
    [TestClass]
    public class MailManager_Test
    {
        [TestMethod]
        public void SendMail_Implementation()
        {
            var mailConfigurator = new Mock<IMailingConfigurator>();

            MailManager mailManager = new MailManager(mailConfigurator.Object);
        }
    }
}
