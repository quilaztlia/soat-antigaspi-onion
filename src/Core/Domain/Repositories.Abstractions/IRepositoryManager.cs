namespace Domain.Repository.Abstractions
{
    public interface IRepositoryManager
    {
        public IOffersRepository OfferRepository { get; }
        public IContactsRepository ContacRepository { get; }

        void Save();
    }
}