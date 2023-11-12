using BuildingWorks.Common.Entities;
using System.Linq.Expressions;

namespace BuildingWorks.Repositories.Specification;

public abstract class Specification<T> : ISpecification<T>
    where T : Entity
{
    public abstract Expression<Func<T, bool>> ToExpression();

    public bool IsSatisfiedBy(T entity)
    {
        var predicate = ToExpression().Compile();

        return predicate(entity);
    }
}
