using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebSite.Backend;
using WebSite.Backend.BusinessEntities;
using WebSite.Backend.Entities;
using WebSite.Tests.WebSite.Backend.Utils;

namespace WebSite.Tests.WebSite.Backend.Manager
{
    [TestClass]
    public class WeddingGuestManager_Test
    {
        [TestMethod]
        public void CreateGuest_IfOneWeddingGuestsIsPassed_ThenShouldSingleGuest()
        {
            WeddingGuestManager weddingGuestManager = new WeddingGuestManager();
            WeddingGuest weddingGuest = WeddingGuestElement.GetCelibWeddingGuest();

            var repoMock = new Mock<IRepository>();
            repoMock
                .Setup(x => x.CreateGuest(It.IsAny<SingleGuest>()))
                .Returns(true);


            weddingGuestManager.Repository = repoMock.Object;

            Assert.IsTrue(weddingGuestManager.CreateGuest(weddingGuest));
            repoMock.Verify(x => x.CreateGuest(It.IsAny<SingleGuest>()), Times.Once);
        }


        [TestMethod]
        public void CreateGuest_IfTwoWeddingGuestsArePassed_ThenShouldCreateCouple()
        {
            WeddingGuestManager weddingGuestManager = new WeddingGuestManager();
            var expectedCouplePartGuest_0 =
                WeddingGuestElement.GetCouplePartOneWeddingGuest();
            var expectedCouplePartGuest_1 =
                WeddingGuestElement.GetCouplePartTwoWeddingGuest();
            (expectedCouplePartGuest_0 as CouplePartGuest).Joint = expectedCouplePartGuest_1;
            (expectedCouplePartGuest_1 as CouplePartGuest).Joint = expectedCouplePartGuest_0;

            var coupleElements = new WeddingGuest[]
                {expectedCouplePartGuest_0, expectedCouplePartGuest_1};

            Couple expectedCouple = new Couple(coupleElements);
            Couple actualCreatedCouple = null;

            var repoMock = new Mock<IRepository>();
            repoMock
                .Setup(x => x.CreateGuest(It.IsAny<Couple>()))
                .Callback<Couple>(couple => actualCreatedCouple = couple)
                .Returns(true);


            weddingGuestManager.Repository = repoMock.Object;

            Assert.IsTrue(weddingGuestManager.CreateGuest(coupleElements));
            repoMock.Verify(x => x.CreateGuest(It.IsAny<Couple>()), Times.Once);

            foreach (var actualCouplePart in actualCreatedCouple.CoupleParts)
            {
                var expectedCouplePart = expectedCouple.CoupleParts.SingleOrDefault(x => x.Id == actualCouplePart.Id);
                var expectedCoupleOtherPart =
                    expectedCouple.CoupleParts.SingleOrDefault(x => x.Id != actualCouplePart.Id);

                Assert.AreEqual(expectedCouplePart.Id, actualCouplePart.Id);
                Assert.AreEqual(expectedCoupleOtherPart.Id, actualCouplePart.Joint.Id);
            }
        }

        [TestMethod]
        public void GetGuestList_Implementation()
        {
            var expectedSingleGuest = Utils.WeddingGuestElement.GetCelibWeddingGuest() as SingleGuest;
            var expectedCoupleGuestPart_0 = Utils.WeddingGuestElement.GetCouplePartOneWeddingGuest() as CouplePartGuest;
            var expectedCoupleGuestPart_1 = Utils.WeddingGuestElement.GetCouplePartTwoWeddingGuest() as CouplePartGuest;

            var expectedWeddingGestList = new List<WeddingGuest>()
            {
                expectedSingleGuest,
                expectedCoupleGuestPart_0,
                expectedCoupleGuestPart_1
            };

            var repoMock = new Mock<IRepository>();
            repoMock
                .Setup(x => x.GetGuestList())
                .Returns(() => expectedWeddingGestList);

            WeddingGuestManager weddingGuestManager = new WeddingGuestManager();
            weddingGuestManager.Repository = repoMock.Object;

            var actualWeddingGestList = weddingGuestManager.GetGuestList();

            foreach (var expectedGuest in expectedWeddingGestList)
            {
                var actualGuest = actualWeddingGestList.SingleOrDefault(x => x.Id == expectedGuest.Id);

                Assert.IsInstanceOfType(actualGuest, expectedGuest.GetType());
            }
        }

        [TestMethod]
        public void DbContext_Implementation()
        {
            string connectionString =
                @"Data Source=ST-NITZSKY\LOCALINSTANCE;Integrated Security=True;Initial catalog=WBST";

            var singleWeddingGuest = (SingleGuest) Utils.WeddingGuestElement.GetCelibWeddingGuest();
            var singleGuest = new Guest();
            //singleGuest.Id = singleWeddingGuest.Id;
            singleGuest.ChildCount = singleWeddingGuest.ChildCount;
            //singleGuest.JointId = singleWeddingGuest.
            singleGuest.Mail = singleWeddingGuest.Mail;
            singleGuest.LastName = singleWeddingGuest.LastName;
            singleGuest.FirstName = singleWeddingGuest.FirstName;

            //using (var guestContext = new GuestContext(connectionString))
            //{
            //    guestContext.Guests.Add(singleGuest);
            //    guestContext.SaveChanges();
            //}

            try
            {
                var guestContext = new GuestContext(connectionString);
                guestContext.Guests.Add(singleGuest);
                guestContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}