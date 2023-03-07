using System;
using FluentValidation;
using NZ_Walks.Repositories;

namespace NZ_Walks.Validators.Walk
{
	public class AddRequestValidator : AbstractValidator<Models.Dto.Walk.AddWalkRequest>
	{
        public AddRequestValidator(IRegionRepository regionRepository)
		{
            RuleFor(x => x.Name).NotEmpty();
			RuleFor(x => x.Length).GreaterThan(0);
			RuleFor(x => x.RegionId).NotEmpty();
			RuleFor(x => x.WalkDifficultyId).NotEmpty();
		}
	}
}

