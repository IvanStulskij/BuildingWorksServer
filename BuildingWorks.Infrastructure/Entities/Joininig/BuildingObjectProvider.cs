using BuildingWorks.Infrastructure.Entities.Providers;

namespace BuildingWorks.Infrastructure.Entities.Joininig;

public class BuildingObjectProvider
{
    public Guid BuildingObjectsId { get; set; }
    public virtual BuildingObject BuildingObject { get; set; } = null!;

    public Guid ProvidersId { get; set; }
    public virtual Provider Provider { get; set; } = null!;
}
