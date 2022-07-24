namespace Domain.Repository.Abstractions
{
    public interface IUnitOfWork
    {
        //CHECK
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
