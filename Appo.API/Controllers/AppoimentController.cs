using Appo.API.DTOs;
using Appo.Aplication.Utilities.Mediator;
using Appo.Application.Features.Appoiments.CreatedAppoiment;
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
    }
}


