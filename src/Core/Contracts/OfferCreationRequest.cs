namespace Contracts
{
    public class OfferCreationRequest
    {
        public string Title { get; set; } = default!;
        public string CompanyName { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Email {get; set; } = default!;
        public string Addresse { get; set; } = default!;
                
        public DateTimeOffset? Avaibility { get; set; } = default;
        public DateTimeOffset? Expiration { get; set; } = default;
    }
}