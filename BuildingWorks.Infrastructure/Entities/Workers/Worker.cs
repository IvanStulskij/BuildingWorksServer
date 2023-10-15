using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure.Entities.Joininig;

namespace BuildingWorks.Infrastructure.Entities.Workers;

public class Worker : Entity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public DateTime StartWorkDate { get; set; }
    public string Post { get; set; } = string.Empty;

    public Guid? BrigadierBrigadeId { get; set; }
    public virtual Brigade? BrigadierBrigade { get; set; }
    public virtual ICollection<Brigade> Brigades { get; set; } = null!;

    public virtual ICollection<WorkerSalary> WorkerSalaries { get; set; } = null!;
    public virtual ICollection<BrigadeWorker> BrigadeWorkers { get; set; } = null!;
}
