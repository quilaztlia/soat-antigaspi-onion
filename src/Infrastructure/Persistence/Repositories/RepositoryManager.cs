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
        }

        public IOffersRepository OfferRepository
        {
            get
            {
                if (_offerRepository == null)
                    _offerRepository = new OffersRepository(_appDbContext);
                return _offerRepository;
            }            
        }

        public IContactsRepository ContacRepository
        {
            get
            {
                if (_contactRepository == null)
                    _contactRepository = new ContactsRepository(_appDbContext);
                return _contactRepository;
            }            
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }
    }
}
