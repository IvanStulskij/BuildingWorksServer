using AutoMapper;
using BuildingWorks.Common.Entities;
using BuildingWorks.Infrastructure.Entities.Workers;
using BuildingWorks.Models.Overviews.Workers;
using BuildingWorks.Models.Resources.Workers;
using BuildingWorks.Repositories.Abstractions.Workers;
using BuildingWorks.Services.Interfaces.Workers;
using FluentValidation;

namespace BuildingWorks.Services.Implementations.Workers;

public class BrigadeService : OverviewService<Brigade, BrigadeResource, BrigadeOverview>, IBrigadeService
{
    private readonly IBrigadeRepository _repository;

    public BrigadeService(IMapper mapper, IBrigadeRepository repository, IValidator<BrigadeResource> validator) : base(mapper, repository, validator)
    {
        _repository = repository;
    }

    public async Task AddWorker(Guid id, Guid workerId)
    {
        await _repository.AddWorker(id, workerId);
    }

    public async Task<IEnumerable<DictionaryItem>> GetShortInfos()
    {
        var entities = await _repository.GetShortInfos();

        return entities;
    }

    public async Task<IEnumerable<Worker>> GetWorkers(Guid brigadeId)
    {
        var workers = await _repository.GetWorkers(brigadeId);

        return workers;
    }
}
