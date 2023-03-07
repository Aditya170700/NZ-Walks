using System;
using FluentValidation;
using NZ_Walks.Models.Dto;

namespace NZ_Walks.Validators.WalkDifficulty
{
	public class UpdateRequestValidator : AbstractValidator<Models.Dto.WalkDifficulty.UpdateWalkDifficultyRequest>
	{
		public UpdateRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
	}
}

