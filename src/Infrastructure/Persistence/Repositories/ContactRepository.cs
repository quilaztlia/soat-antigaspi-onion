using Domain.Repository.Abstractions;
using Persistence.Tsql;

namespace Persistence.Repositories
{
    internal sealed class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ContactRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
