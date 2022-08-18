using Domain.Repository.Abstractions;
using Persistence.Repositories;

namespace Persistence.Tsql
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _appDbContext;

        private IOffersRepository _offerRepository;
        private IContactsRepository _contactRepository;

        public RepositoryManager(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _offerRepository = new OffersRepository(_appDbContext);
            _contactRepository = new ContactsRepository(_appDbContext);
        }

        public IOffersRepository OfferRepository
        {
            get
            {
                return _offerRepository;
            }            
        }

        public IContactsRepository ContacRepository
        {
            get
            {
               return _contactRepository;
            }            
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }
    }
}
