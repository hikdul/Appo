
using Appo.Aplication.Utilities.Mediator;

namespace Appo.Aplication.Features.Companys.Commands
{

    public class CreateCompanyCommand: IRequest<Guid>
    {
		public required string Name { get; set; }
		public string? Description { get; set; }
    }
}
