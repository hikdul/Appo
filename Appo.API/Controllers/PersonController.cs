using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Mvc;
using Appo.API.DTOS;
using Appo.Application.Features.Persons.Query.GetListPersons;
using Appo.Aplication.Utilities.Mediator;
using Appo.API.DTOs.Person;
using Appo.Core.ObjectValues;
using Appo.Application.Features.Persons.Commands.CreatePerson;
using Appo.Application.Features.Persons.Commands.UpdatePerson;

namespace Appo.API.Controllers
{
	[ApiController]
	[Route("api/Persons")]
    public class PersonController: ControllerBase
    {
		private readonly IMediator mediator;

		public PersonController(IMediator _mediator)
		{
		    this.mediator = _mediator;
		}


		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Person_in ins)
		{
			var command = new CreatePersonCommand { Name = ins.Name, LastName = ins.LastName, Email = ins.Email, PhoneNumber = ins.PhoneNumber };
			await mediator.Send(command);
			return Created();
		}


		[HttpPut("{Id}")]
		public async Task<IActionResult> Put(Guid Id, [FromBody] Person_in ins)
		{
			var command = new UpdatePersonCommand {Id = Id, Name = ins.Name, LastName = ins.LastName, Email = ins.Email, PhoneNumber = ins.PhoneNumber };
			await  mediator.Send(command);
			return Ok();
		}


		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var request = new GetListPersonsQuery();
			var response = await mediator.Send(request);
			return Ok(response);
		}

    }
}
