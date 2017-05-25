namespace WebSite.Backend.BusinessEntities
{
    public class WeddingGuest
    {
        public int Id { get; set; }
        public int ChildCount { get; set; }
        public string Mail { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool IsRequested { get; set; }
        public bool IsResponded { get; set; }
    }
}