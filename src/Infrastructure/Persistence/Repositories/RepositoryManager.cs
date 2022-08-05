using Domain.Repository.Abstractions;

namespace Persistence.Tsql
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        public IOfferRepository OfferRepository { set => throw new NotImplementedException(); }
        public IContactRepository ContacRepository { set => throw new NotImplementedException(); }
    }
}
