namespace Contracts
{
    public class ContactDto
    {
        //public int Id { get; set; }
        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
        
        public string? Email { get; init; }
        public string? Message { get; init; }        
        public Guid OfferId { get; init; }

        public override bool Equals(object? obj)
        {
            if(obj == null || obj.GetType() != this.GetType())
                return false;
            
            var contactDto = obj as ContactDto;
            if(   contactDto?.FirstName == this.FirstName
               && contactDto.LastName == this.LastName 
               && contactDto.Email == this.Email 
               && contactDto.Message == this.Message    
               && contactDto.OfferId == this.OfferId)
                return true;

            return false;
        }
    }
}