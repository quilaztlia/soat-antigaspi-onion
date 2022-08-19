using Domain.Entities;
using Domain.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using Persistence.Tsql;
using Persistence.Tsql.Repositories;

namespace Persistence.Repositories
{
    internal sealed class OffersRepository
            : RepositoryBase<Offer>, IOffersRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public OffersRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _appDbContext = dbContext;
        }

        public IEnumerable<Offer> GetAllOffers()
        {
            return FindAll()
                .OrderBy(o => o.Id)
                .ToList();
        }

        public Offer? GetOfferById(Guid idOffer)
        {
            return FindByCondition(q => q.Id == idOffer)
                .FirstOrDefault();
        }

        public void CreateOffer(Offer offer)
            => Create(offer);

        public void UpdateOffer(Offer offer)
            => Update(offer);

        public void DeleteOffer(Offer offer)
            => Delete(offer);

        //CHECK: Include, ToList, CancellationToken
        async Task<IReadOnlyCollection<Offer>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _appDbContext
                    .Offers
                    .ToListAsync(cancellationToken);


    }
}
