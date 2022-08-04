using Contracts;
using Services.Abstractions;

namespace Domain.Services
{
    //CHECK: internam & sealed
    public sealed class ContactService : IContactService
    {
        //public ContactService()
        //{
        //}
        public async Task<ContactDto> GetContact(Guid idContact)
        {
            throw new NotImplementedException();
        }
    }
}