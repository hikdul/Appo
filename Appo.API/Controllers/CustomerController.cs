using Appo.Aplication.Utilities.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Appo.API.Controllers
{

	[ApiController]
	[Route("api/Customer")]
    public class CustomerController: ControllerBase
    {

		private readonly IMediator mediator;

		public CustomerController(IMediator _mediator)
		{
		    this.mediator = _mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Post()
		{
			//TODO: Completar esto cuando se trabaje con el tenancy

			return Ok();
		}
    }
}
