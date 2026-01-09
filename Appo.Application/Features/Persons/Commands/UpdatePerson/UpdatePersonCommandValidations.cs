
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace Appo.Application.Features.Persons.Commands.UpdatePerson
{
	public class UpdatePersonCommandValidations:AbstractValidator<UpdatePersonCommand>
	{
		public UpdatePersonCommandValidations()
		{

			RuleFor(c => c.Name)
				.MaximumLength(100)
				.WithMessage("The Name, your name is Required.");

			RuleFor(c => c.LastName)
				.MaximumLength(100)
				.WithMessage("Sometime is wrong whit your LastName..");

			RuleFor(c => c.Email)
				.EmailAddress()
				.WithMessage("The Email address is not correctly.");

			RuleFor(c => c.PhoneNumber)
				.MaximumLength(100)
				.WithMessage("This phone number is to lange.");
		}
	}
}



