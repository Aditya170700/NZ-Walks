using System;
using FluentValidation;
using NZ_Walks.Models.Dto.Auth;

namespace NZ_Walks.Validators.Auth
{
	public class RegisterValidator : AbstractValidator<RegisterRequest>
	{
		public RegisterValidator()
		{
			RuleFor(x => x.Username).NotEmpty();
			RuleFor(x => x.Email).NotEmpty();
			RuleFor(x => x.Email).EmailAddress();
			RuleFor(x => x.Password).NotEmpty();
			RuleFor(x => x.Password).Equal(x => x.PasswordConfirmation);
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
        }
	}
}

