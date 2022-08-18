using Domain.Entities;
using Domain.Repository.Abstractions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactServer.Test.Mocks
{
    internal class MockIContactsRepository
    {
        public static Mock<IContactsRepository> GetMock()
        {
            var mock = new Mock<IContactsRepository>();

            var contacts = new List<Contact>()
            {
                new Contact
                {
                    Id = 1,
                     LastName = "LastName1",
                     FirstName = "FirsName1"
                },
                 new Contact
                {
                     Id=2, 
                     LastName = "LastName2",
                     FirstName = "FirsName2"
                },
            };

            mock.Setup(m => m.GetAllContacts())
                .Returns(() => contacts);

            mock.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns((int id) => contacts.FirstOrDefault(c => c?.Id == id)); 


            return mock;
        }
    }
}
