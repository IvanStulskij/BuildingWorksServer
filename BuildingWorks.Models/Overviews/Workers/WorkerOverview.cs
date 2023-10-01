using BuildingWorks.Common;

namespace BuildingWorks.Models.Overviews.Workers;

public class WorkerOverview : Entity, IOverview
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public DateTime StartWorkDate { get; set; }
    public string Post { get; set; } = string.Empty;
    public bool IsBrigadier { get; set; }
    public BrigadeOverview Brigade { get; set; } = null!;
}
