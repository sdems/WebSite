using System.Data.Entity;

namespace WebSite.Backend.Entities
{
    public class GuestContext:DbContext
    {
        public GuestContext():base()
        {
        }

        public GuestContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<Guest> Guests { get; set; }
    }
}