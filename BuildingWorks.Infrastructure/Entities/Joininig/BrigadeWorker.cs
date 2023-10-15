using BuildingWorks.Infrastructure.Entities.Workers;

namespace BuildingWorks.Infrastructure.Entities.Joininig;

public class BrigadeWorker
{
    public DateTime StartWorkDate { get; set; }
    public DateTime? EndWorkDate { get; set; }

    public Guid BrigadesId { get; set; }
    public virtual Brigade Brigade { get; set; } = null!;

    public Guid WorkersId { get; set; }
    public virtual Worker Worker { get; set; } = null!;
}
