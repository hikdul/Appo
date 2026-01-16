using Appo.API.DTOs;
using Appo.Aplication.Utilities.Mediator;
using Appo.Application.Features.Appoiments.CreatedAppoiment;
using Appo.Application.Features.Appoiments.Querys.GetListAppoiment;
using Microsoft.AspNetCore.Mvc;

namespace Appo.API.Controllers
{
	[ApiController]
	[Route("api/Appoiment")]
    public class AppoimentController: ControllerBase
    {
		private readonly IMediator mediator;

		public AppoimentController(IMediator _mediator)
		{
		    this.mediator = _mediator;
		}


		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Appoiment_in dto)
		{
			var command = new CreatedAppoimentCommand {Start = dto.Start, Finish =  dto.Finish, CustomerId = dto.CustomerId, CustomerRequest = dto.CustomerRequest, PartnerId = dto.PartnerId };
			await mediator.Send(command);
			return Ok();
		}

		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] GetListAppoimentQuery query)
		{
			var result = await mediator.Send(query);
			return Ok(result);
		}
    }
}


