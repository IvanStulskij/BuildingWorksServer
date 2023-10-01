using BuildingWorks.Common.Configuration;
using BuildingWorks.Models.Resources.Workers;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace BuildingWorks.Validation.Validators.Workers;

public class BrigadeValidator : AbstractValidator<BrigadeResource>
{
	public BrigadeValidator(IOptions<WorkerSettings> options)
	{
		RuleFor(brigade => brigade.Number.Length)
			.LessThanOrEqualTo(options.Value.NumberMaxLength);
	}
}
