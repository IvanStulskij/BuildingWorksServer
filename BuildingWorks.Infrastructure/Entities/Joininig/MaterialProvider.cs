using BuildingWorks.Infrastructure.Entities.Providers;

namespace BuildingWorks.Infrastructure.Entities.Joininig;

public class MaterialProvider
{
    public Guid ProvidersId { get; set; }
    public virtual Provider Provider { get; set; }

    public Guid MaterialsId { get; set; }
    public virtual Material Material { get; set; }
}
