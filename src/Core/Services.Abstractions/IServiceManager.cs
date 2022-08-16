namespace Services.Abstractions
{
    public interface IServiceManager
    {
        //IMapper Mapper { get; }
        IOfferService OfferService { get; }
        IContactService ContactService { get; }
    }
}