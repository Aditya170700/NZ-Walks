using System;
using FluentValidation;
using NZ_Walks.Models.Dto.Auth;

namespace NZ_Walks.Validators.Auth
{
	public class LoginValidator : AbstractValidator<LoginRequest>
	{
		public LoginValidator()
		{
			RuleFor(x => x.Username).NotEmpty();
			RuleFor(x => x.Password).NotEmpty();
        }
	}
}

