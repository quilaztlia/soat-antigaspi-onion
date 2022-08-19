using Domain.Entities;
using Domain.Repositories.Abstractions;

namespace Domain.Repository.Abstractions
{
    public interface IOffersRepository 
        : IRepositoryBase<Offer>
    {
        void CreateOffer(Offer offer);
        void UpdateOffer(Offer offer);
        void DeleteOffer(Offer offer);
        IEnumerable<Offer> GetAllOffers();
        Offer GetOfferById(Guid idOffer);        
    }
}