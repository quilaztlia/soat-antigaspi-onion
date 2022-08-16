using Moq;
using Services.Abstractions;

namespace ContactServer.Test.Mock
{
    internal class MockServiceManager
    {
        public static Mock<IServiceManager> GetMock()
        {
            var mock = new Mock<IServiceManager>();

            mock.Setup(m => m.ContactService)
                .Returns(() => new Mock<IContactService>().Object);

            mock.Setup(m => m.OfferService)
                .Returns(() => new Mock<IOfferService>().Object);

            return mock;
        }
    }
}
