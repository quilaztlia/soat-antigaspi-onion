using Domain.Entities;
using Domain.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using Persistence.Tsql;
using Persistence.Tsql.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class OffersRepository : RepositoryBase<Offer>, IOffersRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        //CHECK: Not an Interface ?
        public OffersRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _appDbContext = dbContext;
        }

        //CHECK: Include, ToList
        protected async Task<IReadOnlyCollection<Offer>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await _appDbContext.Offers.ToListAsync(cancellationToken);
    }
}
