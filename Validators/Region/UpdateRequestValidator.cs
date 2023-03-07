using System;
using FluentValidation;
using NZ_Walks.Models.Dto;

namespace NZ_Walks.Validators.Region
{
	public class UpdateRequestValidator : AbstractValidator<UpdateRegionRequest>
	{
		public UpdateRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Area).GreaterThan(0);
            RuleFor(x => x.Population).GreaterThanOrEqualTo(0);
        }
	}
}

