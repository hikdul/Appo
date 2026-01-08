using Appo.Aplication.Utilities.Mediator;
using Appo.API.DTOs.WorkCompany;
using Microsoft.AspNetCore.Mvc;
using Appo.Application.Features.WorkCenter.Commands.CreateWorkCenter;
using Appo.Core.ObjectValues;
using Appo.Application.Features.WorkCenter.Commands.UpWorkCenter;
using Appo.Application.Features.WorkCenter.Querys.GetWorkCenterDetails;

namespace Appo.API.Controllers
{

	[ApiController]
	[Route("api/WorkCompany")]
	public class WorkCompanyController: ControllerBase
	{
		private readonly IMediator mediator;

		public WorkCompanyController(IMediator _mediator)
		{
			this.mediator = _mediator;
		}


		[HttpPost]
		public async Task<IActionResult> Post([FromBody] WorkCompany_in ins)
		{
			var dir = new Direction(ins.Direction,ins.Latitud, ins.Longitud);
			var command = new CreateWorkCenterCommand { Name = ins.Name, Direction = dir };
			await mediator.Send(command);
			return Created();
		}


		[HttpPut("{Id}")]
		public async Task<IActionResult> Put(Guid Id, [FromBody] WorkCompany_in ins)
		{
			var command = new UpWorkCenterCommand {Id = Id, Name = ins.Name, Direction = ins.Direction, Latitud = ins.Latitud, Longitud = ins.Longitud };
			await  mediator.Send(command);
			return Ok();
		}


		[HttpGet("{Id}")]
		public async Task<IActionResult> Get(Guid Id)
		{
			var query = new GetWorkCenterDetailsQuery { Id = Id };
			var response = await mediator.Send(query);
			return Ok(response);
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var query = new GetListCompanysQuery();
			var response = await mediator.Send(query);
			return Ok(response);
		}

	}
}


