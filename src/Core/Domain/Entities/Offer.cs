namespace Domain.Entities
{
    public class Offer
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string CompanyName { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Email { get; set; } = default!; 
        public string Address { get; set; } = default!;
          
        public OfferStatus Status { get; set; }
        public DateTime? Availability { get; set; }
        public DateTime? Expiration { get; set; }
    }
}