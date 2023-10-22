using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure.Entities.Joininig;

namespace BuildingWorks.Infrastructure.Entities.Workers;

public class Brigade : Entity
{
    public string Number { get; set; } = string.Empty;

    public Guid BuildingObjectId { get; set; }
    public virtual BuildingObject BuildingObject { get; set; } = null!;
    public Guid? BrigadierId { get; set; }
    public virtual Worker? Brigadier { get; set; } = null!;

    public virtual ICollection<Worker> Workers { get; set; } = null!;
    public virtual ICollection<BrigadeWorker> BrigadeWorkers { get; set; } = null!;
}
