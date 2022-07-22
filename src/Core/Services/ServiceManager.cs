using Domain.IRepository;
using Services.Abstractions;

namespace Domain
{
    internal sealed class ServiceManager : IServiceManager
    {
         
        //CHECK: Lazy creation, Lazy Loading
        public ServiceManager()
        {
        
        }

        public IOfferService OfferService => throw new NotImplementedException();

        public IContactService ContactService => throw new NotImplementedException();
    }
}