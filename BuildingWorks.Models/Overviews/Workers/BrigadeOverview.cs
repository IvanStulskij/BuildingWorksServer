using BuildingWorks.Common.Entities;
using BuildingWorks.Models.Overviews.BuildingObjects;

namespace BuildingWorks.Models.Overviews.Workers;

public class BrigadeOverview : Entity, IOverview
{
    public string Number { get; set; } = string.Empty;
    public int WorkersCount { get; set; }

    public BuildingObjectOverview BuildingObject { get; set; } = null!;
    public WorkerOverview? Brigadier { get; set; }
}
