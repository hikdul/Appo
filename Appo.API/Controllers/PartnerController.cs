using Appo.Aplication.Utilities.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Appo.API.Controllers
{

	[ApiController]
	[Route("api/Partner")]
	public class PartnerController: ControllerBase
	{

		private readonly IMediator mediator;

		public PartnerController(IMediator _mediator)
		{
			this.mediator = _mediator;
		}


		[HttpPost]
		public async Task<IActionResult> Post()
		{
			// Todo: completar esta opcion cuando se defina el modo de trabajo
			return Ok();
		}
	}
}
