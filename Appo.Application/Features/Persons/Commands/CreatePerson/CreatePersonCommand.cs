using Appo.Aplication.Utilities.Mediator;

namespace Appo.Application.Features.Persons.Commands.CreatePerson
{
    public class CreatePersonCommand: IRequest<Guid>
    {
		public string Name { get; set; }
		public string? LastName { get; set; }
		public string? Email { get; set; }
		public string? PhoneNumber { get; set; }
    }
}
