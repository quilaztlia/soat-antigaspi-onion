using Domain.Entities;
using Domain.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class OfferRepository : IOfferRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        //CHECK: Not an Interface ?
        public OfferRepository(ApplicationDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        //CHECK: Include, ToList
        protected async Task<IReadOnlyCollection<Offer>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await _appDbContext.Offers.ToListAsync(cancellationToken);
    }
}
