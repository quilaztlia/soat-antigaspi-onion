using Domain.Entities;
using Domain.Repositories.Abstractions;

namespace Domain.Repository.Abstractions
{
    public interface IContactsRepository : IRepositoryBase<Contact>
    {
    }
}