namespace Domain.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; init; } = String.Empty;
        public string LastName { get; init; } = String.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Message { get; set; }        
        public Guid OfferId { get; set; }

        public DateTimeOffset CreationDatetime { get; init; } = DateTimeOffset.UtcNow;
    }
}