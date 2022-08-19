using ContactServer.Test.Mocks;
using Contracts;
using Domain.Entities;
using Domain.Services;
using LoggerService;
using LoggerService.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Presentation.Rest;

namespace PresentationRest.Test
{
    public class OfferControllerTest
    {
        ICustomLoggerManager _logger = new CustomLoggerManager(new ConfigurationManager());

        [Fact]
        public void CreateOffer_Should_ReturnOK_When_ValidCreationRequest()
        {
            var offers = new List<Offer>()
            {
                new Offer(){}
            };

            var offersRepository = MockIOffersRepository.GetMock(offers);
            var repositoryManager = MockRepositoryManager.GetOffersMock(offersRepository);
            var serviceManager = new ServiceManager(repositoryManager.Object);

            var offerController = new OffersController(_logger, serviceManager);

            var newOffer = new OfferCreationRequest
            {
                Title = "Still working chair",
                CompanyName = "Soat",
                Description = "Nice confy chair",
                Email = "a@soat.fr",
                Addresse = "Paris XIII",
                Avaibility = DateTimeOffset.Parse("2022-08-19"),
                Expiration = DateTimeOffset.Parse("2022-08-31")
            };

            var offerResult = offerController.CreateOffer(newOffer) as ObjectResult;

            Assert.NotNull(offerResult);
            Assert.Equal(StatusCodes.Status201Created, offerResult.StatusCode);
            Assert.IsAssignableFrom<OfferDto>(offerResult.Value);
            Assert.NotNull(offerResult.Value as OfferDto);
            Assert.Equal("OfferById", (offerResult as CreatedAtRouteResult)?.RouteName);
            //Assert.NotEqual(default, (offerResult.Value as OfferDto).Id);//CHECK: IntegrationTest responsability?
        }     
    }
}
