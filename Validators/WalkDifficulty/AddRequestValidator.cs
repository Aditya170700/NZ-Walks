using System;
using FluentValidation;

namespace NZ_Walks.Validators.WalkDifficulty
{
	public class AddRequestValidator : AbstractValidator<Models.Dto.WalkDifficulty.AddWalkDifficultyRequest>
	{
        public AddRequestValidator()
		{
            RuleFor(x => x.Name).NotEmpty();
        }
	}
}

