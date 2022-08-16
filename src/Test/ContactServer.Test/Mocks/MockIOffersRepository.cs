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
    }
}
