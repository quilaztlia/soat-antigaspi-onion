using Contracts;

namespace Services.Abstractions
{
    public interface IContactService
    {
        public Task<ContactDto> GetContact(Guid idContact);
    }
}