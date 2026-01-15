using Appo.Aplication.Utilities.Mediator;

namespace Appo.Application.Features.Customers.Command.CreateCustomer
{
    public class CreateCustomerCommand: IRequest
    {
		public Guid TenantId { get; set; }
		public Guid PersonId { get; set; }
    }
}
