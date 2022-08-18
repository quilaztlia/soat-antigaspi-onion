using ContactServer.Test.Mocks;
using Domain.Services;
using Moq;
using PresentationRest.Test.Mocks;
using Services.Abstractions;

namespace ContactServer.Test.Mock
{
    internal class MockServiceManager
    {
        public static IServiceManager GetMock()
        {
            var repositoryManager = MockRepositoryManager.GetMock();           
            
            var serviceManager = new ServiceManager(repositoryManager.Object);

            //CHECK: Dont understand this !
            //var contactServiceMock = MockIContactService.GetMock();
            //var mock = new Mock<IServiceManager>();
            //mock.Setup(m => m.ContactService)
            //    .Returns(() => contactServiceMock.Object);
        
            return serviceManager;
        }
    }
}
