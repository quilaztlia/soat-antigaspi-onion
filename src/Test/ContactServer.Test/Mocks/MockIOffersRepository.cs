using Domain.Entities;
using Domain.Repository.Abstractions;
using Moq;

namespace ContactServer.Test.Mocks
{
    internal class MockIOffersRepository
    {
        public static Mock<IOffersRepository> GetMock() { 
            var mock = new Mock<IOffersRepository>();

            var offers = new List<Offer>()
            {
                new Offer
                {
                    Id = Guid.Parse("1"), 
                    Title = "McokedOfferTitle1",
                },
                new Offer {
                    Id = Guid.Parse("2"),
                    Title = "McokedOfferTitle2",
                }
            };           

            return mock;
        }

        //CHECK: Has sens to mock? Bcs I have no return
        //      So how to check if well added (Id = NotFilled)
        public static Mock<IOffersRepository> GetMock(List<Offer> offers)
        {
            var mock = new Mock<IOffersRepository>();

            mock.Setup(r => r.CreateOffer(It.IsAny<Offer>()));
                //.Returns((Offer newOffer) => offers.Add(newOffer));     
            
            return mock;
        }
    }
}
