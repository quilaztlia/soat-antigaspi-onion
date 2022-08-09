using Domain.Entities;
using Domain.Repository.Abstractions;
using Persistence.Tsql;
using Persistence.Tsql.Repositories;

namespace Persistence.Repositories
{
    internal sealed class ContactsRepository 
        : RepositoryBase<Contact>, IContactsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ContactsRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
