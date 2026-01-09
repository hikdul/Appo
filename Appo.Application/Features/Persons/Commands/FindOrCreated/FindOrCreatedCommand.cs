using Appo.Aplication.Utilities.Mediator;

namespace Appo.Application.Features.Persons.Commands.FindOrCreated
{
    public class FindOrCreatedCommand: IRequest<Guid>
    {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string? LastName { get; set; }
		public string? Email { get; set; }
		public string? PhoneNumber { get; set; }
    }
}
