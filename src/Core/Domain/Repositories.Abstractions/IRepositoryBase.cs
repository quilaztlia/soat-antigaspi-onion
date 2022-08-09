using System.Linq.Expressions;

namespace Domain.Repositories.Abstractions
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        void Update(T entity);
        void Create(T entity);
        void Delete(T entity);
    }
}
