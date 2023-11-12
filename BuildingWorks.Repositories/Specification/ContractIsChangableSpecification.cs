using BuildingWorks.Infrastructure.Entities.Providers;
using System.Linq.Expressions;

namespace BuildingWorks.Repositories.Specification;

public class ContractIsChangableSpecification : Specification<Contract>
{
    public override Expression<Func<Contract, bool>> ToExpression()
    {
        return contract => contract.SignedOn == null;
    }
}