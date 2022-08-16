using Contracts;
using Domain.Entities;
using Domain.Repository.Abstractions;
using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.Rest;
using Services.Abstractions;

namespace ContactServer.Test
{
    public class ContactControllerTest
    {
        [Fact]
        public void GetAll_Should_Return200AndAll2Contacts_When_Ok()
        {                                
            var all2ContactsMocked = new List<Contact>()
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

            var contactRepoMocked = new Mock<IContactsRepository>();
            contactRepoMocked.Setup(r => r.GetAllContacts())
                .Returns(all2ContactsMocked);
            
            var contactServiceMock = new Mock<IContactService>();
            contactServiceMock.Setup(s => s.GetAllContacts())
                .Returns(() => contactRepoMocked.Object.GetAllContacts());

            var serviceManager = new Mock<IServiceManager>();
            serviceManager.Setup(x => x.ContactService)
                .Returns(() => contactServiceMock.Object);

            var logger = new CustomLoggerManager(null);
            
            var contactController = new ContactsController(logger, serviceManager.Object);

            var result = contactController.GetAllContacts() as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<ContactDto>(result.Value);
            Assert.NotNull(result.Value as ContactDto);


        }
    }
}