namespace Domain.IRepository
{
    public interface IUnitOfWork
    {
        //CHECK
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
