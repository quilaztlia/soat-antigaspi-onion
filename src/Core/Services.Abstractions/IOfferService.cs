using Contracts;

namespace Services.Abstractions
{
    public interface IOfferService
    {
        Task<OfferDto> GetOffer(Guid offerID);

        Task<IReadOnlyCollection<OfferDto>> GetAllOffers();
    }
}