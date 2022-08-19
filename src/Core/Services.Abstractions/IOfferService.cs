using Contracts;

namespace Services.Abstractions
{
    public interface IOfferService
    {
        OfferDto CreateOffer(OfferCreationRequest offer);
        IEnumerable<OfferDto> GetAllOffers();
        OfferDto GetOfferById(Guid id);

        Task<OfferDto> CreateOfferAsync(OfferCreationRequest offer);
        Task<OfferDto> GetOfferByIdAsync(Guid offerID);
        Task<IReadOnlyCollection<OfferDto>> GetAllOffersAsync();
        
        
    }
}