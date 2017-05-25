using System.Collections.Generic;
using WebSite.Backend.BusinessEntities;

namespace WebSite.Backend
{
    public interface IRepository
    {
        bool CreateGuest(Couple couple);
        bool CreateGuest(SingleGuest guest);
        IEnumerable<WeddingGuest> GetGuestList();
    }
}