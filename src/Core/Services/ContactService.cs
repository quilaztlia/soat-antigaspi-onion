using Contracts;
using Domain.Repository.Abstractions;
using Services.Abstractions;
using Mapster;

namespace Domain.Services
{
    //CHECK: internam & sealed
    public sealed class ContactService : IContactService
    {
        private readonly IContactsRepository _contactsRepository;

        public ContactService(IRepositoryManager repositoryManager)
        {
            _contactsRepository = repositoryManager.ContacRepository;            
        }

        //IReadOnlyCollection
        public IEnumerable<ContactDto> GetAllContacts()
        {            
            var contacts = _contactsRepository.GetAllContacts();

            var contactsDto = contacts.Adapt<IEnumerable<ContactDto>>();

            return contactsDto;
        }

        public ContactDto GetContact(int idContact)
        {
           var contact = _contactsRepository.GetById(idContact);

            var contactDto = contact.Adapt<ContactDto>();

            return contactDto;
        }

        Task<ContactDto> IContactService.GetContact(int idContact)
        {
            throw new NotImplementedException();
        }
    }
}