using Contracts;
using Domain.Entities;
using Domain.Repository.Abstractions;
using Domain.Services;
using LoggerService;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Presentation.Rest;

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

            var contactRepositoryMocked = new Mock<IContactsRepository>();
            contactRepositoryMocked.Setup(r => r.GetAllContacts())
                .Returns(all2ContactsMocked);

            var repositoryManagerMocked = new Mock<IRepositoryManager>();
            repositoryManagerMocked.Setup(r => r.ContacRepository)
                .Returns(() => contactRepositoryMocked.Object);

            var serviceManager = new ServiceManager(repositoryManagerMocked.Object);
            var logger = new CustomLoggerManager(new ConfigurationManager()); //Class:IConfiguration

            var contactController = new ContactsController(logger, serviceManager);

            //Act
            var result = contactController.GetAllContacts() as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result?.StatusCode);
            Assert.IsAssignableFrom<IEnumerable<ContactDto>>(result?.Value);
            Assert.NotNull(result?.Value as IEnumerable<ContactDto>);
            Assert.Equal(all2ContactsMocked.Adapt<IEnumerable<ContactDto>>(), result?.Value as IEnumerable<ContactDto>);
            //Assert.Equal(all2ContactsMocked.First().FirstName, contactResult.First().FirstName);
        }

        [Fact]
        public void GetAll_Should_Return200AndNoContacts_When_Ok()
        {
            //Arrange
            var contactsMock = new List<Contact>();

            var contactRepository = new Mock<IContactsRepository>();
            contactRepository.Setup(r => r.GetAllContacts())
                .Returns(contactsMock);

            var repositoryManager = new Mock<IRepositoryManager>();
            repositoryManager.Setup(rm => rm.ContacRepository)
                .Returns(() => contactRepository.Object);
            
            var serviceManager = new ServiceManager(repositoryManager.Object);
            var logger = new CustomLoggerManager(new ConfigurationManager());

            var contactController = new ContactsController(logger, serviceManager);

            //Act
            var result = contactController.GetAllContacts() as ObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result?.StatusCode);
            Assert.IsAssignableFrom<IEnumerable<ContactDto>>(result?.Value);
            Assert.Equal(contactsMock.Adapt<IEnumerable<ContactDto>>(), result?.Value);
        }


    }
}