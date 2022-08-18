using ContactServer.Test.Mocks;
using Moq;
using Services.Abstractions;

namespace PresentationRest.Test.Mocks
{
    internal class MockIContactService
    {
        public static Mock<IContactService> GetMock()
        {
            var mock = new Mock<IContactService>();
            var repo = MockIContactsRepository.GetMock();

            //CHECK: Dont understand this !
            // mock.Setup(s => s.).Returns();

            return mock;
        }
    }
}
