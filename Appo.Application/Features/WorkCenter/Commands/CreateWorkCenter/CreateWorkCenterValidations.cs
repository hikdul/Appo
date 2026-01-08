
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using FluentValidation;
using FluentValidation.Results;

namespace Appo.Application.Features.WorkCenter.Commands.CreateWorkCenter
{
    public class CreateWorkCenterValidations: AbstractValidator<CreateWorkCenterCommand>
    {
		public CreateWorkCenterValidations()
		{
		    RuleFor(c => c.Name)
				.NotNull()
				.WithMessage("The Company Name is Required");
		}
    }
}


