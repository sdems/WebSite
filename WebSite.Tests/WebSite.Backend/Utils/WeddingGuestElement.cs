using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Backend.BusinessEntities;

namespace WebSite.Tests.WebSite.Backend.Utils
{
    public static class WeddingGuestElement
    {
        #region Variables

        static int singleGuestId_0 = 0;
        static int singleChildCount_0 = 1;
        static string singleGuestMail_0 = "CelibPerso@mail.com";
        static bool singleGuestIsRequested_0 = false;
        static bool singleGuestIsResponded_0 = false;
        static string singleGuestLastName_0 = "Nom de famille celib";
        static string singleGuestFirstName_0 = "Prénom Celib";
        static bool singleGuestIsAccompanied_0 = false;

        //CoupleParts 
        static int coupleChildCount = 3;
        static string coupleChildLastName = "coupleChildLastName";
        // SingleGuest 1
        static int singleGuestId_1 = 1;
        static int singleChildCount_1 = coupleChildCount;
        static string singleGuestMail_1 = "CouplePerso_0@mail.com";
        static bool singleGuestIsRequested_1 = false;
        static bool singleGuestIsResponded_1 = false;
        static string singleGuestLastName_1 = "Nom de famille CouplePerso_0";
        static string singleGuestFirstName_1 = "Prénom CouplePerso_0";

        // SingleGuest 2
        static int singleGuestId_2 = 2;
        static int singleChildCount_2 = coupleChildCount;
        static string singleGuestMail_2 = "CouplePerso_2@mail.com";
        static bool singleGuestIsRequested_2 = false;
        static bool singleGuestIsResponded_2 = false;
        static string singleGuestLastName_2 = "Nom de famille CouplePerso_2";
        static string singleGuestFirstName_2 = "Prénom CouplePerso_2";

        #endregion

        public static WeddingGuest GetCouplePartTwoWeddingGuest()
        {
            WeddingGuest coupleWeddingGuest_1 = new CouplePartGuest();
            coupleWeddingGuest_1.Id = singleGuestId_2;
            coupleWeddingGuest_1.ChildCount = singleChildCount_2;
            coupleWeddingGuest_1.Mail = singleGuestMail_2;
            coupleWeddingGuest_1.LastName = singleGuestLastName_2;
            coupleWeddingGuest_1.FirstName = singleGuestFirstName_2;
            coupleWeddingGuest_1.IsRequested = singleGuestIsResponded_2;
            coupleWeddingGuest_1.IsResponded = singleGuestIsResponded_2;
            return coupleWeddingGuest_1;
        }

        public static WeddingGuest GetCouplePartOneWeddingGuest()
        {
            WeddingGuest coupleWeddingGuest_0 = new CouplePartGuest();
            coupleWeddingGuest_0.Id = singleGuestId_1;
            coupleWeddingGuest_0.ChildCount = singleChildCount_1;
            coupleWeddingGuest_0.Mail = singleGuestMail_1;
            coupleWeddingGuest_0.LastName = singleGuestLastName_1;
            coupleWeddingGuest_0.FirstName = singleGuestFirstName_1;
            coupleWeddingGuest_0.IsRequested = singleGuestIsResponded_1;
            coupleWeddingGuest_0.IsResponded = singleGuestIsResponded_1;
            return coupleWeddingGuest_0;
        }

        public static WeddingGuest GetCelibWeddingGuest()
        {
            WeddingGuest celibSingleWeddingGuest = new SingleGuest();
            celibSingleWeddingGuest.Id = singleGuestId_0;
            celibSingleWeddingGuest.ChildCount = singleChildCount_0;
            celibSingleWeddingGuest.Mail = singleGuestMail_0;
            celibSingleWeddingGuest.LastName = singleGuestLastName_0;
            celibSingleWeddingGuest.FirstName = singleGuestFirstName_0;
            celibSingleWeddingGuest.IsRequested = singleGuestIsResponded_0;
            celibSingleWeddingGuest.IsResponded = singleGuestIsResponded_0;
            (celibSingleWeddingGuest as SingleGuest).IsAccompanied = singleGuestIsAccompanied_0;

            return celibSingleWeddingGuest;
        }
    }
}
