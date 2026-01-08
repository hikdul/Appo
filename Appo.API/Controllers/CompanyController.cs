
using Appo.Aplication.Features.Companys.Commands;
using Appo.Aplication.Utilities.Mediator;
using Microsoft.AspNetCore.Mvc;
using Appo.API.DTOS;
using Appo.Aplication.Features.Companys.Querys;
using System.Diagnostics.Eventing.Reader;

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
			try
			{
				var command = new CreateCompanyCommand { Name = ins.Name, Description = ins.Description };
				await mediator.Send(command);
				return Created();
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error al crear el huevon");
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.InnerException?.Message);
				throw;
			}
		}


		[HttpPut("{Id}")]
		public async Task<IActionResult> Put(Guid Id, [FromBody] Company_up ins)
		{
			var command = new EditCompanyCommand {Id = Id, Name = ins.Name, Description = ins.Description};
			await  mediator.Send(command);
			return Ok();
		}


		[HttpGet("{Id}")]
		public async Task<IActionResult> Get(Guid Id)
		{
			var query = new GetDetailsCompanyQuery { Id = Id };
			CompanyOut response = await mediator.Send(query);
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

