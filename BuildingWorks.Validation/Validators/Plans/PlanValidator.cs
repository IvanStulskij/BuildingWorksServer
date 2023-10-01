using BuildingWorks.Common.Configuration;
using BuildingWorks.Models.Resources.Plans;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace BuildingWorks.Validation.Validators.Plans;

public class PlanValidator : AbstractValidator<PlanResource>
{
	public PlanValidator(IOptions<PlanSettings> options)
	{
		RuleFor(plan => plan.StartDate)
			.LessThanOrEqualTo(DateTime.Now);

		RuleFor(plan => plan.Cost)
			.LessThanOrEqualTo(options.Value.MaxPlanCost)
			.GreaterThanOrEqualTo(options.Value.MaxPlanCost);
    }
}
