using Contracts;
using Domain.Entities;
using Domain.Repository.Abstractions;
using Mapster;
using Services.Abstractions;

namespace Domain.Services
{
    //CHECK: internal https://bityl.co/DOgx
    public sealed class OfferService : IOfferService
    {
        private readonly IOffersRepository _offersRepository;
        private readonly IRepositoryManager _repositoryManager;

        public OfferService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
            _offersRepository = repositoryManager.OfferRepository;
        }

        public OfferDto CreateOffer(OfferCreationRequest newOffer)
        {
            var offer = newOffer.Adapt<Offer>();
            
            _offersRepository.CreateOffer(offer);
            _repositoryManager.Save();

            return offer.Adapt<OfferDto>();            
        }

        public OfferDto GetOfferById(Guid id)
        {
            var offer = _offersRepository.GetOfferById(id);

            return offer.Adapt<OfferDto>();
        }

        public IEnumerable<OfferDto> GetAllOffers()
        {
            var offers = _offersRepository.GetAllOffers();

            return offers.Adapt<IEnumerable<OfferDto>>();
        }

        public Task<OfferDto> CreateOfferAsync(OfferCreationRequest offer)
        {
            throw new NotImplementedException();
        }

        public Task<OfferDto> GetOfferByIdAsync(Guid offerID)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<OfferDto>> GetAllOffersAsync()
        {
            throw new NotImplementedException();
        }        
    }
}