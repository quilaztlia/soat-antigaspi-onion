namespace Services.Abstractions
{
    public interface IServiceManager
    {
        IOfferService OfferService { get; }
        IContactService ContactService { get; }
    }
}