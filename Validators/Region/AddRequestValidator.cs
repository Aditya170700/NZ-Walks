using System;
using FluentValidation;

namespace NZ_Walks.Validators.Region
{
	public class AddRequestValidator : AbstractValidator<Models.Dto.AddRegionRequest>
	{
        public AddRequestValidator()
		{
			RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.Area).GreaterThan(0);
			RuleFor(x => x.Population).GreaterThanOrEqualTo(0);
        }
	}
}

