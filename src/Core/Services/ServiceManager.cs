using Domain.Repository.Abstractions;
using Services.Abstractions;

namespace Domain.Services;

public sealed class ServiceManager : IServiceManager
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly Lazy<ContactService> _lazyContactsService;
    private readonly Lazy<OfferService> _lazyOffersService;

    //CHECK: Lazy creation, Lazy Loading
    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;

        _lazyContactsService = new Lazy<ContactService>(() => new ContactService(repositoryManager));
        _lazyOffersService = new Lazy<OfferService>(() => new OfferService(repositoryManager));
    }

    public IOfferService OfferService => _lazyOffersService.Value;

    public IContactService ContactService => _lazyContactsService.Value;
       
}