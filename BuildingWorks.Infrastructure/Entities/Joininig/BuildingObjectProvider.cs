using BuildingWorks.Infrastructure.Entities.Providers;

namespace BuildingWorks.Infrastructure.Entities.Joininig;

public class BuildingObjectProvider
{
    public Guid BuildingObjectId { get; set; }
    public virtual BuildingObject BuildingObject { get; set; } = null!;

    public Guid ProviderId { get; set; }
    public virtual Provider Provider { get; set; } = null!;
}
