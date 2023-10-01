using BuildingWorks.Common.Configuration;
using BuildingWorks.Models.Resources.Workers;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace BuildingWorks.Validation.Validators.Workers;

public class WorkerSalaryValidator : AbstractValidator<WorkerSalaryResource>
{
	public WorkerSalaryValidator(IOptions<WorkerSettings> options)
	{
		RuleFor(workerSalary => workerSalary.AddedOn)
			.LessThanOrEqualTo(DateTime.Now);

		RuleFor(workerSalary => workerSalary.BaseSalary)
			.LessThanOrEqualTo(options.Value.BaseSalaryMax);

		RuleFor(workerSalary => workerSalary.TotalAmount)
			.LessThanOrEqualTo(options.Value.MaxTotalAmount);

		RuleFor(workerSalary => workerSalary.ChildrenCount)
			.LessThanOrEqualTo(options.Value.MaxChildrenCount);

		RuleFor(workerSalary => workerSalary.Experience)
			.LessThanOrEqualTo(options.Value.ExperienceMax);
	}
}
