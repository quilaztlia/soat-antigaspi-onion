using Domain.Repository.Abstractions;

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
