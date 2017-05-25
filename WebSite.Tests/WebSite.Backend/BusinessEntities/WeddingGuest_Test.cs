using Microsoft.VisualStudio.TestTools.UnitTesting;

using WebSite.Backend.BusinessEntities;
using WebSite.Tests.WebSite.Backend.Utils;

namespace WebSite.Tests.WebSite.Backend.BusinessEntities
{
    [TestClass]
    public class WeddingGuest_Test
    {
        [TestMethod]
        public void WeddingGuestShouldBeCreatedAsSingle_Implementation()
        {
            WeddingGuest expectedWeddingGuest = Utils.WeddingGuestElement.GetCelibWeddingGuest();

        }

        [TestMethod]
        public void Implementation()
        {
            var celibSingleWeddingGuest = WeddingGuestElement.GetCelibWeddingGuest();
            var coupleWeddingGuest_0 = WeddingGuestElement.GetCouplePartOneWeddingGuest();
            var coupleWeddingGuest_1 = WeddingGuestElement.GetCouplePartTwoWeddingGuest();

            (coupleWeddingGuest_0 as CouplePartGuest).Joint = coupleWeddingGuest_1;
            (coupleWeddingGuest_1 as CouplePartGuest).Joint = coupleWeddingGuest_0;

            Couple couple =
                new Couple(new CouplePartGuest[]
                    {coupleWeddingGuest_0 as CouplePartGuest, coupleWeddingGuest_1 as CouplePartGuest});
        }

    }
}