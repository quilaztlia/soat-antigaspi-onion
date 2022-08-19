namespace Contracts
{
    public class OfferDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string CompanyName { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Email { get; set; } = default!;
        //CHECK: Double relational Status ?? how dojo does?
        //public OfferStatus Status { get; set; }
    }
}
