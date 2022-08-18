using Domain.Repository.Abstractions;
using Moq;

namespace ContactServer.Test.Mocks
{
    internal class MockRepositoryManager
    {
        public static Mock<IRepositoryManager> GetMock(Mock<IContactsRepository> contactsRepository)
        {
            var mock = new Mock<IRepositoryManager>();
          
            mock.Setup(m => m.ContacRepository)
                .Returns(() => contactsRepository.Object);
          
            mock.Setup(m => m.Save())
                .Callback(() => { return; });

            return mock;
        }

        public static Mock<IRepositoryManager> GetMock(Mock<IOffersRepository> offersRepository)
        {
            var mock = new Mock<IRepositoryManager>();

            mock.Setup(m => m.OfferRepository)
                .Returns(() => offersRepository.Object);

            mock.Setup(m => m.Save())
                .Callback(() => { return; });

            return mock;
        }
        
        public static Mock<IRepositoryManager> GetMock()
        {           
            var mock = new Mock<IRepositoryManager>();

            var contacRepoMock = MockIContactsRepository.GetMock();
            var offerRepoMock = MockIOffersRepository.GetMock();

            mock.Setup(m => m.ContacRepository)
                .Returns(() => contacRepoMock.Object);

            mock.Setup(m => m.OfferRepository)
                .Returns(() => offerRepoMock.Object);

            mock.Setup(m => m.Save())
                .Callback(() => { return; });

            return mock;
        }
    }
}
