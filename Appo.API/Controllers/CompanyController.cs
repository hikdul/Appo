
using System;
using Appo.Aplication.Features.Companys.Commands;
using Appo.Aplication.Utilities.Mediator;
using Microsoft.AspNetCore.Mvc;
using Appo.API.DTOS;
using Appo.Aplication.Features.Companys.Querys;

namespace Appo.API.Controllers
{
	[ApiController]
	[Route("api/Company")]
	public class CompanyController: ControllerBase
	{

		private readonly IMediator mediator;

		public CompanyController(IMediator _mediator)
		{
			this.mediator = _mediator;
		}


		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Company_in ins)
		{
			var command = new CreateCompanyCommand { Name = ins.Name, Description = ins.Description };
			await mediator.Send(command);
			return Created();
		}


		[HttpGet("{Id}")]
		public async Task<IActionResult> Get(Guid Id)
		{
			var query = new GetDetailsCompanyQuery { Id = Id };
			CompanyOut response = await mediator.Send(query);
			return Ok(response);
		}

	}
}

