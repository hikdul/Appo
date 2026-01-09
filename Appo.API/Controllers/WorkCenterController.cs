using Appo.Aplication.Utilities.Mediator;
using Appo.API.DTOs.WorkCenter;
using Microsoft.AspNetCore.Mvc;
using Appo.Application.Features.WorkCenter.Commands.CreateWorkCenter;
using Appo.Core.ObjectValues;
using Appo.Application.Features.WorkCenter.Commands.UpWorkCenter;
using Appo.Application.Features.WorkCenter.Querys.GetWorkCenterDetails;
using Appo.Application.Features.WorkCenter.Querys.GetListWorkCenter;

namespace Appo.API.Controllers
{

	[ApiController]
	[Route("api/WorkCenter")]
	public class WorkCenterController: ControllerBase
	{
		private readonly IMediator mediator;

		public WorkCenterController(IMediator _mediator)
		{
			this.mediator = _mediator;
		}


		[HttpPost]
		public async Task<IActionResult> Post([FromBody] WorkCenter_in ins)
		{
			var dir = new Direction(ins.Direction,ins.Latitud, ins.Longitud);
			var command = new CreateWorkCenterCommand { Name = ins.Name, Direction = dir };
			await mediator.Send(command);
			return Created();
		}


		[HttpPut("{Id}")]
		public async Task<IActionResult> Put(Guid Id, [FromBody] WorkCenter_in ins)
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
			var query = new GetListWorkCenterQuery();
			var response = await mediator.Send(query);
			return Ok(response);
		}

	}
}


