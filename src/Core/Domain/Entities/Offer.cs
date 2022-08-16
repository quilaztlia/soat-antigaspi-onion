namespace Domain.Entities
{
    public class Offer
    {
        public DateTimeOffset? Availability { get; set; }
        public DateTimeOffset? Expiration { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Guid Id { get; set; }        
        public OfferStatus Status { get; set; }
    }
}