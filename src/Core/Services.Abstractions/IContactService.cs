using Contracts;

namespace Services.Abstractions
{
    public interface IContactService
    {
        public Task<ContactDto> GetContact(int idContact);

        public IEnumerable<ContactDto> GetAllContacts();        
    }
}