namespace Domain.Entities
{
    public class Contact
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }

        public Guid OfferId { get; set; }

        public DateTimeOffset CreationDatetime { get; set; }
    }
}