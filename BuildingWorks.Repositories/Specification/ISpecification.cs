using BuildingWorks.Common.Entities;
using System.Linq.Expressions;

namespace BuildingWorks.Repositories.Specification;

public interface ISpecification<T> where T : Entity
{
    bool IsSatisfiedBy(T entity);
    Expression<Func<T, bool>> ToExpression();
}
