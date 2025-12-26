
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FluentValidation;
using FluentValidation.Results;


namespace Appo.Aplication.Features.Companys.Commands
{
	public class CreateCompanyCommandValidation: AbstractValidator<CreateCompanyCommand>
	{
		public CreateCompanyCommandValidation()
		{
		    RuleFor(c => c.Name)
				.NotNull()
				.WithMessage("The Company Name is Required");
		}
		
	}
}
