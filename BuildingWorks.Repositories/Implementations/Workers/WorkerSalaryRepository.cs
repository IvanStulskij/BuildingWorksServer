using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities.Workers;
using BuildingWorks.Models.Overviews.Workers;
using BuildingWorks.Repositories.Abstractions.Workers;
using BuildingWorks.Repositories.Query;

namespace BuildingWorks.Repositories.Implementations.Workers;

public class WorkerSalaryRepository : OverviewRepository<WorkerSalary, WorkerSalaryOverview>, IWorkerSalaryRepository
{
    public WorkerSalaryRepository(BuildingWorksDbContext context) : base(context)
    {
    }

    protected override IQueryable<WorkerSalaryOverview> IncludeHierarchy()
    {
        return Set.IncludeHierarchy().Select(x => new WorkerSalaryOverview
        {
            Id = x.Id,
            AddedOn = x.AddedOn,
            BaseSalary = x.BaseSalary,
            ChildrenCount = x.ChildrenCount,
            Experience = x.Experience,
            TotalAmount = x.TotalAmount,
            WorkedDays = x.WorkedDays,
        });
    }
}
