using BuildingWorks.Models.Overviews;
using BuildingWorks.Models.Resources;

namespace BuildingWorks.Services.Interfaces;

public interface IService<TResource>
    where TResource : IResource
{
    IEnumerable<TResource> GetAll();

    Task<TResource> GetById(Guid id);

    Task<TResource> Create(TResource resource);

    Task<TResource> Update(TResource resource);

    Task Delete(Guid id);
}

public interface IOverviewService<TResource, TOverview> : IService<TResource>
        where TResource : IResource
        where TOverview : IOverview
{
    IEnumerable<TOverview> GetAllOverview();
}