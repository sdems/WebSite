using System.Collections.Generic;
using WebSite.Backend.BusinessEntities;

namespace WebSite.Backend.BusinessEntities
{
    public class WeddingGuestManager
    {
        public IRepository Repository { get; set; }

        public bool CreateGuest(WeddingGuest guest)
        {
            return Repository.CreateGuest(guest as SingleGuest);
        }

        public bool CreateGuest(WeddingGuest[] coupleParts)
        {
            (coupleParts[0] as CouplePartGuest).Joint = coupleParts[1];
            (coupleParts[1] as CouplePartGuest).Joint = coupleParts[0];

            return Repository.CreateGuest(new Couple(coupleParts));
        }

        public IEnumerable<WeddingGuest> GetGuestList()
        {
            throw new System.NotImplementedException();
        }
    }
}