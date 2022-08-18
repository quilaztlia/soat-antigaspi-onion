using Contracts;

namespace Services.Abstractions
{
    public interface IContactService
    {
        public ContactDto GetContact(int idContact);

        public IEnumerable<ContactDto> GetAllContacts();

        public Task<ContactDto> GetContactAsync(int idContact);
    }
}