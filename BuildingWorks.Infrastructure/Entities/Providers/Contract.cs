using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure.Entities.Plans;

namespace BuildingWorks.Infrastructure.Entities.Providers;

public class Contract : Entity
{
    public DateTime SignedOn { get; set; }
    public string Conditions { get; set; } = string.Empty;

    public virtual IEnumerable<Plan> Plans { get; set; } = null!;
    public virtual ICollection<Provider> Providers { get; set; } = null!;
    public virtual ICollection<Material> Materials { get; set; } = null!;
}
