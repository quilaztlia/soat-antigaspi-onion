using Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class OfferRepository : IOfferRepository
    {
        private readonly RepositoryDbContext _dbContext;

        //CHECK: Not an Interface ?
        public OfferRepository(RepositoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
