using BuildingWorks.Infrastructure.Entities.Workers;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Repositories.Query;

public static class BrigadeQuery
{
    public static IQueryable<Brigade> IncludeHierarchy(this IQueryable<Brigade> brigades)
    {
        return brigades
            .Include(brigade => brigade.BuildingObject)
            .Include(brigade => brigade.Workers)
            .Include(brigade => brigade.Brigadier);
    }
}
