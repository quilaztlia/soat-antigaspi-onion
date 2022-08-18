using Domain.Entities;
using Domain.Repository.Abstractions;
using Moq;

namespace ContactServer.Test.Mocks
{
    internal class MockIContactsRepository
    {
        public static Mock<IContactsRepository> GetMock(List<Contact> contacts)
        {
            var mock = new Mock<IContactsRepository>();
          
            mock.Setup(m => m.GetAllContacts())
                .Returns(() => contacts);

            mock.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns((int idContact) => contacts?.FirstOrDefault(c => c?.Id == idContact)); 

            return mock;
        }

        public static Mock<IContactsRepository> GetMock()
        {
            var contacts = new List<Contact>()
            {
               new Contact
                {
                     Id = 1,
                     CreationDatetime = DateTime.Now,
                     Email = "firstContact@soat.fr",
                     Phone = "0600000001",
                     LastName = "LastName1",
                     FirstName = "FirsName1",
                     OfferId = new Guid(),
                     Message =  "I am contact 1"
                },
               new Contact
                {
                     Id=2,
                     CreationDatetime = DateTime.Now,
                     Email = "secondContact@soat.fr",
                     Phone = "0600000002",
                     LastName = "LastName2",
                     FirstName = "FirsName2",
                     OfferId = new Guid(),
                     Message = "I am contact 2"
                },
            };

            var mock = new Mock<IContactsRepository>();

            mock.Setup(m => m.GetAllContacts())
                .Returns(() => contacts);

            mock.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns((int idContact) => contacts?.FirstOrDefault(c => c?.Id == idContact));

            return mock;
        }
    }
}
