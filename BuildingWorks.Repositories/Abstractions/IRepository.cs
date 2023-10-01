using BuildingWorks.Common.Entities;
using System.Linq.Expressions;

namespace BuildingWorks.Repositories.Abstractions;

public interface IRepository<T>
    where T : Entity
{
    Task<T> GetById(Guid id);
    IQueryable<T> Get();
    Task<T> Insert(T entity);
    Task Insert(IEnumerable<T> entities);
    Task<T> Update(T entity);
    Task Delete(Guid id);
    IQueryable<T> GetByCondition(Expression<Func<T, bool>> condition);
}