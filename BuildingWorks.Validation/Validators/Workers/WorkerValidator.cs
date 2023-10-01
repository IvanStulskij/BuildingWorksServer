using BuildingWorks.Models.Resources.Workers;
using FluentValidation;

namespace BuildingWorks.Validation.Validators.Workers;

public class WorkerValidator : AbstractValidator<WorkerResource>
{
	public WorkerValidator()
	{
		RuleFor(worker => worker.StartWorkDate)
			.LessThanOrEqualTo(DateTime.Now);
	}
}
