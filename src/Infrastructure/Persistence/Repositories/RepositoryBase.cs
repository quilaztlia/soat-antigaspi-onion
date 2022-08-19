using Domain.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Tsql.Repositories
{
    public abstract class RepositoryBase<T> 
        : IRepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext _repositoryContext;

        public RepositoryBase(ApplicationDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Create(T entity)
        {
            _repositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _repositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _repositoryContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
           return _repositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
          return  _repositoryContext.Set<T>()
                .Where(expression).AsNoTracking();
        }
    }
}
