using BuildingWorks.Common.Configuration;
using BuildingWorks.Models.Resources.Providers;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace BuildingWorks.Validation.Validators.Providers;

public class MaterialValidator : AbstractValidator<MaterialResource>
{
	public MaterialValidator(IOptions<MaterialSettings> options)
	{
		RuleFor(material => material.Name.Length)
			.LessThanOrEqualTo(options.Value.NameMaxLength);

        RuleFor(material => material.Measure.Length)
            .LessThanOrEqualTo(options.Value.MeasureMaxLength);
    }
}
