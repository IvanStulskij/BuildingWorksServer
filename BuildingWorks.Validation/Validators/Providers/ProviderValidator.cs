using BuildingWorks.Common.Configuration;
using BuildingWorks.Models.Resources.Providers;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace BuildingWorks.Validation.Validators.Providers;

public class ProviderValidator : AbstractValidator<ProviderResource>
{
	public ProviderValidator(IOptions<ProviderSettings> options)
	{
		RuleFor(provider => provider.Name.Length)
			.LessThanOrEqualTo(options.Value.NameMaxLength);

        RuleFor(provider => provider.Country.Length)
            .LessThanOrEqualTo(options.Value.CountryMaxLength);

        RuleFor(provider => provider.Signer.Length)
            .LessThanOrEqualTo(options.Value.SignerMaxLength);

        RuleFor(provider => provider.AdditionalData.Length)
            .LessThanOrEqualTo(options.Value.AdditionalDataMaxLength);
    }
}
