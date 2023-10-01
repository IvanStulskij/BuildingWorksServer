using AutoMapper;
using BuildingWorks.Infrastructure.Entities;
using BuildingWorks.Models.Overviews.BuildingObjects;
using BuildingWorks.Models.Resources.BuildingObjects;
using BuildingWorks.Repositories.Abstractions.BuildingObjects;
using BuildingWorks.Repositories.Implementations;
using BuildingWorks.Services.Interfaces.BuildingObjects;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace BuildingWorks.Services.Implementations.BuildingObjects;

public class BuildingObjectService : OverviewService<BuildingObject, BuildingObjectResource, BuildingObjectOverview>, IBuildingObjectService
{
    public BuildingObjectService(IMapper mapper, IBuildingObjectRepository repository, IValidator<BuildingObjectResource> validator) : base(mapper, repository, validator)
    {
    }
}