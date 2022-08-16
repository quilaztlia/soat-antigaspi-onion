using Contracts;
using Domain.Repository.Abstractions;
using Services.Abstractions;

namespace Domain.Services
{
    //CHECK: internal https://bityl.co/DOgx
    public sealed class OfferService : IOfferService
    {
        private readonly IOffersRepository _offersRepository;

        public OfferService(IRepositoryManager repositoryManager)
        {
            _offersRepository = repositoryManager.OfferRepository;
        }

        public Task<IReadOnlyCollection<OfferDto>> GetAllOffers()
        {
            throw new NotImplementedException();
        }

        public Task<OfferDto> GetOffer(Guid offerID)
        {
            throw new NotImplementedException();
        }
       
    }
}