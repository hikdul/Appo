
using Appo.Aplication.Utilities.Mediator;

namespace Appo.Aplication.Features.Companys.Commands
{

	public class EditCompanyCommand: IRequest
	{
		public required Guid Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
	}
}
