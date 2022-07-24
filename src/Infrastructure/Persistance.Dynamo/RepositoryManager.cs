using Domain.Repository.Abstractions;

namespace Persistance.Dynamo
{
    public class RepositoryManager : IRepositoryManager
    {
        public IOfferRepository OfferRepository { set => throw new NotImplementedException(); }
        public IContactRepository ContacRepository { set => throw new NotImplementedException(); }
    }
}
