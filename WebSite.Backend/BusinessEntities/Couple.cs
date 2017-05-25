namespace WebSite.Backend.BusinessEntities
{
    public class Couple
    {
        public Couple(WeddingGuest[] coupleParts)
        {
            _coupleParts = new CouplePartGuest[]
            {
                coupleParts[0] as CouplePartGuest, coupleParts[1] as CouplePartGuest
            };
        }

        private readonly CouplePartGuest[] _coupleParts;

        public CouplePartGuest[] CoupleParts
        {
            get { return _coupleParts; }
        }
    }
}