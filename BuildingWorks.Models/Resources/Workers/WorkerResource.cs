using BuildingWorks.Common;

namespace BuildingWorks.Models.Resources.Workers;

public class WorkerResource : Entity, IResource
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public DateTime StartWorkDate { get; set; }
    public string Post { get; set; } = string.Empty;
    public Guid? BrigadierBrigadeId { get; set; }
    public Guid BrigadeId { get; set; }
}
