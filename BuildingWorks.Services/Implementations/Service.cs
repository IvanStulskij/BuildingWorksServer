using AutoMapper;
using BuildingWorks.Common.Entities;
using BuildingWorks.Models.Overviews;
using BuildingWorks.Models.Resources;
using BuildingWorks.Repositories.Abstractions;
using BuildingWorks.Services.Interfaces;
using FluentValidation;

namespace BuildingWorks.Services.Implementations;

public abstract class Service<T, TResource> : IService<TResource>
    where T : Entity
    where TResource : IResource
{
    private readonly IValidator<TResource> _validator;

    protected IMapper Mapper { get; init; }
    protected IRepository<T> Repository { get; init; }
    
    public Service(IMapper mapper, IRepository<T> repository, IValidator<TResource> validator)
    {
        Mapper = mapper;
        Repository = repository;
        _validator = validator;
    }

    public async Task<TResource> Create(TResource resource)
    {
        _validator.ValidateAndThrow(resource);
        var created = await Repository.Insert(Mapper.Map<T>(resource));

        return Mapper.Map<TResource>(created);
    }

    public async Task Delete(Guid id)
    {
        await Repository.Delete(id);
    }

    public IEnumerable<TResource> GetAll()
    {
        return Mapper.Map<IEnumerable<TResource>>(Repository.Get());
    }

    public async Task<TResource> GetById(Guid id)
    {
        var entity = await Repository.GetById(id);

        return Mapper.Map<TResource>(entity);
    }

    public async Task<TResource> Update(TResource resource)
    {
        _validator.ValidateAndThrow(resource);
        var updated = await Repository.Update(Mapper.Map<T>(resource));

        return Mapper.Map<TResource>(updated);
    }
}

public abstract class OverviewService<T, TResource, TOverview> : Service<T, TResource>, IOverviewService<TResource, TOverview>
    where T : Entity
    where TResource : IResource
    where TOverview : IOverview
{
    protected IOverviewRepository<T> OverviewRepository { get; init; }

    protected OverviewService(IMapper mapper, IOverviewRepository<T> repository, IValidator<TResource> validator) : base(mapper, repository, validator)
    {
        OverviewRepository = repository;
    }

    public virtual IEnumerable<TOverview> GetAllOverview()
    {
        return Mapper.Map<IEnumerable<TOverview>>(OverviewRepository.GetOverviewDisplayedData());
    }
}