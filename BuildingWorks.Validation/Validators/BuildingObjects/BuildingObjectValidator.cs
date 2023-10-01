using BuildingWorks.Common.Configuration;
using BuildingWorks.Models.Resources.BuildingObjects;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace BuildingWorks.Validation.Validators.BuildingObjects;

public class BuildingObjectValidator : AbstractValidator<BuildingObjectResource>
{
    public BuildingObjectValidator(IOptions<BuildingObjectSettings> options)
    {
        RuleFor(buildingObject => buildingObject.ObjectName.Length)
            .LessThanOrEqualTo(options.Value.NameMaxLength);

        RuleFor(buildingObject => buildingObject.ObjectCustomer.Length)
            .LessThanOrEqualTo(options.Value.CustomerMaxLength)
            .When(buildingObject => buildingObject.ObjectCustomer != null);

        RuleFor(buildingObject => buildingObject.ExecutorCompany.Length)
            .LessThanOrEqualTo(options.Value.ExecutorCompanyMaxLength);
    }
}