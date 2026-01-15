using Appo.Aplication.Utilities.Mediator;
using Appo.Core.Entities;

namespace Appo.Application.Features.Persons.Commands.FindOrCreated
{
    public class FindOrCreatedCommand: IRequest<Person>
    {
		public string Name { get; set; }
		public string? LastName { get; set; }
		public string? Email { get; set; }
		public string? PhoneNumber { get; set; }
    }
}
