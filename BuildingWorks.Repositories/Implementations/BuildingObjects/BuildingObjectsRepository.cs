﻿using BuildingWorks.Common.Constants;
using BuildingWorks.Common.Entities;
using BuildingWorks.Common.Exceptions;
using BuildingWorks.Infrastructure;
using BuildingWorks.Infrastructure.Entities;
using BuildingWorks.Infrastructure.Entities.Joininig;
using BuildingWorks.Infrastructure.Loading;
using BuildingWorks.Models.Overviews;
using BuildingWorks.Models.Overviews.BuildingObjects;
using BuildingWorks.Models.Overviews.Providers;
using BuildingWorks.Models.Overviews.Workers;
using BuildingWorks.Repositories.Abstractions.BuildingObjects;
using BuildingWorks.Repositories.Abstractions.Plans;
using BuildingWorks.Repositories.Abstractions.Workers;
using BuildingWorks.Repositories.Common;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Repositories.Implementations.BuildingObjects;

public class BuildingObjectsRepository : OverviewRepository<BuildingObject, BuildingObjectOverview>, IBuildingObjectRepository
{
    private readonly IPlanRepository _plansRepository;
    private readonly IBrigadeRepository _brigadesRepository;
    private readonly IDatabaseChanges _databaseChanges;
    private readonly ILoader<BrigadeOverview> _brigadeLoader;
    private readonly ILoader<ProviderOverview> _providersLoader;
    private readonly ILoader<OrderOverview> _orderLoader;

    public BuildingObjectsRepository(BuildingWorksDbContext context, IPlanRepository plansRepository, IBrigadeRepository brigadesRepository, IDatabaseChanges databaseChanges, ILoader<BrigadeOverview> brigadeLoader, ILoader<ProviderOverview> providerLoader, ILoader<OrderOverview> orderLoader) : base(context)
    {
        _plansRepository = plansRepository;
        _brigadesRepository = brigadesRepository;
        _databaseChanges = databaseChanges;
        _brigadeLoader = brigadeLoader;
        _providersLoader = providerLoader;
        _orderLoader = orderLoader;
    }

    public async Task AddProvider(Guid id, Guid providerId)
    {
        var entity = new BuildingObjectProvider
        {
            BuildingObjectsId = id,
            ProvidersId = providerId,
        };

        await Context.BuildingObjectProvider.AddAsync(entity);
        await _databaseChanges.TrySaveChanges(ErrorsConstants.Messages.BuildingObjectAlreadyHasProvider);
    }

    public async Task<float> CalculateTotalCost(Guid buildingObjectId)
    {
        var buildingObject = await Set.AsNoTracking()
            .Include(buildingObject => buildingObject.Brigades)
            .Include(buildingObject => buildingObject.Plans)
            .FirstOrDefaultAsync(buildingObject => buildingObject.Id == buildingObjectId);

        return 0;
    }

    public async Task DeleteProvider(Guid id, Guid providerId)
    {
        var deletedCount = await Context.BuildingObjectProvider
            .Where(entity => entity.ProvidersId == providerId && entity.BuildingObjectsId == id)
            .ExecuteDeleteAsync();

        if (deletedCount == 0)
        {
            throw new EntityNotExistException($"Provider with id {providerId}");
        }
    }

    public async Task<LoadResult<BrigadeOverview>> GetBrigades(Guid buildingObjectId, LoadConditions loadConditions)
    {
        var loadQuery = Context.Brigades
            .Where(brigade => brigade.BuildingObjectId == buildingObjectId)
            .Include(brigade => brigade.Brigadier)
            .Include(brigade => brigade.BuildingObject)
            .Select(brigade => new BrigadeOverview
            {
                Id = brigade.Id,
                WorkersCount = Context.BrigadeWorker.Count(entity => entity.BrigadesId == brigade.Id),
                Number = brigade.Number,
                BuildingObject = new BuildingObjectOverview
                {
                    Id = brigade.BuildingObject.Id,
                    ObjectName = brigade.BuildingObject.ObjectName,
                    BuildingObjectType = brigade.BuildingObject.BuildingObjectType,
                    BuildingObjectTypeName = brigade.BuildingObject.BuildingObjectTypeName,
                    ExecutorCompany = brigade.BuildingObject.ExecutorCompany,
                    ObjectCustomer = brigade.BuildingObject.ObjectCustomer
                },
                Brigadier = brigade.Brigadier == null ? null : new WorkerOverview
                {
                    Id = brigade.Brigadier.Id,
                    FirstName = brigade.Brigadier.FirstName,
                    LastName = brigade.Brigadier.LastName,
                    MiddleName = brigade.Brigadier.MiddleName,
                    Post = brigade.Brigadier.Post,
                    IsBrigadier = brigade.Brigadier.Brigades.Any(),
                    StartWorkDate = brigade.Brigadier.StartWorkDate,
                }
            });
        var loadedData = await _brigadeLoader.Load(loadQuery, loadConditions);

        return loadedData;
    }

    public async Task<LoadResult<OrderOverview>> GetOrders(Guid buildingObjectId, LoadConditions loadConditions)
    {
        var orders = Context.Orders.AsNoTracking()
            .Where(order => order.BuildingObjectId == buildingObjectId)
            .Select(order => new OrderOverview
            {
                Id = order.Id,
                FactDeliveredAt = order.FactDeliveredAt,
                PlannedDeliveredAt = order.PlannedDeliveredAt,
                StartDeliverAt = order.StartDeliverAt,
                Status = order.Status,
                Cost = order.Cost,
                ProviderName = order.ProviderName,
                OrderId = order.OrderID
            });

        var result = await _orderLoader.Load(orders, loadConditions);
        return result;
    }

    public async Task<LoadResult<ProviderOverview>> GetProviders(Guid buildingObjectId, LoadConditions loadConditions)
    {
        var loadQuery = Context.BuildingObjectProvider.AsNoTracking()
            .Include(provider => provider.Provider)
            .Where(entity => entity.BuildingObjectsId == buildingObjectId)
            .Select(entity => new ProviderOverview
            {
                Id = entity.ProvidersId,
                Name = entity.Provider.Name,
                Signer = entity.Provider.Signer,
                AdditionalData = entity.Provider.AdditionalData,
                Country = entity.Provider.Country
            });

        var loadedData = await _providersLoader.Load(loadQuery, loadConditions);

        return loadedData;
    }

    public async Task<IEnumerable<DictionaryItem>> GetProvidersShortInfos(Guid buildingObjectId)
    {
        var shortInfos = await Context.BuildingObjectProvider.AsNoTracking()
            .Include(provider => provider.Provider)
            .Where(entity => entity.BuildingObjectsId == buildingObjectId)
            .Select(entity => new DictionaryItem
            {
                Id = entity.ProvidersId.ToString(),
                Name = entity.Provider.Name
            }).ToListAsync();

        return shortInfos;
    }

    protected override IQueryable<BuildingObjectOverview> IncludeHierarchy()
    {
        return Set.Select(x => new BuildingObjectOverview
        {
            Id = x.Id,
            BuildingObjectType = x.BuildingObjectType,
            BuildingObjectTypeName = x.BuildingObjectTypeName,
            ExecutorCompany = x.ExecutorCompany,
            ObjectCustomer = x.ObjectCustomer,
            ObjectName = x.ObjectName
        });
    }

    private float CalculatePlansCost()
    {
        return 0;
    }
}