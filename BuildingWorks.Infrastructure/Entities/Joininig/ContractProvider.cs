using BuildingWorks.Infrastructure.Entities.Providers;

namespace BuildingWorks.Infrastructure.Entities.Joininig;

public class ContractProvider
{
    public Guid ContractsId { get; set; }
    public virtual Contract Contract { get; set; } = null!;

    public Guid ProvidersId { get; set; }
    public virtual Provider Provider { get; set; } = null!;
}
