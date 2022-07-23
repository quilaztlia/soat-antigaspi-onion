using Domain.IRepository;

namespace Persistence.Repositories
{
    internal sealed class ContactRepository : IContactRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public ContactRepository(RepositoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
