namespace Domain.Repository.Abstractions
{
    public interface IRepositoryManager
    {
        public IOfferRepository OfferRepository { set; }
        public IContactRepository ContacRepository { set; }
    }
}