using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite.Backend.Entities
{
    public class Guest
    {
        public int Id { get; set; }
        public int ChildCount { get; set; }
        public int? JointId { get; set; }
        public string Mail { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool IsRequested { get; set; }
        public bool IsResponded { get; set; }
        public bool IsAccompanied { get; set; }
        
        public virtual Guest Joint { get; set; }
    }

    public class WedGuest
    {
        public int WedGuestId { get; set; }
        public int CoupleId { get; set; }
        //public int? JointId { get; set; }
        public string Mail { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool IsRequested { get; set; }
        public bool IsResponded { get; set; }
        public bool IsAccompanied { get; set; }

        public virtual Guest Joint { get; set; }
    }

    public class Couple
    {
        public int ChildCount { get; set; }
        public int CoupleId { get; set; }

        public IList<Guest> Joints { get; set; }
    }

    public class Single
    {

    }
}
