namespace Domain.Entities
{
    public class Offer
    {
        public DateTime Availability { get; set; }
        public DateTime Expiration { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}