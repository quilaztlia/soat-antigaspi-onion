using Moq;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationRest.Test.Mocks
{
    internal class MockIOfferService
    {
        public static Mock<IOfferService> GetMock()
        {
            var mock = new Mock<IOfferService>();

            //mock.Setup(s => s.GetAllOffers()) .Returns(() =>  );

                return mock;
        }
    }
}
