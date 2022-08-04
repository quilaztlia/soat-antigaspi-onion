using Contracts;
using Services.Abstractions;

namespace Domain.Services
{
    //CHECK: internal https://bityl.co/DOgx
    public sealed class OfferService : IOfferService
    {
        //public OfferService()
        //{
        //}

        public Task<OfferDto> GetOffer(Guid offerID)
        {
            throw new NotImplementedException();
        }
    }
}