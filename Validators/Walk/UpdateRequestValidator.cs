using System;
using FluentValidation;
using NZ_Walks.Models.Dto;

namespace NZ_Walks.Validators.Walk
{
	public class UpdateRequestValidator : AbstractValidator<Models.Dto.Walk.UpdateWalkRequest>
	{
		public UpdateRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Length).GreaterThan(0);
            RuleFor(x => x.RegionId).NotEmpty();
            RuleFor(x => x.WalkDifficultyId).NotEmpty();
        }
	}
}

