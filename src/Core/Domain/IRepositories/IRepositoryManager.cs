namespace Domain.IRepository
{
    public interface IRepositoryManager
    {
        public IOfferRepository OfferRepository { set; }
        public IContactRepository ContacRepository { set; }
    }
}